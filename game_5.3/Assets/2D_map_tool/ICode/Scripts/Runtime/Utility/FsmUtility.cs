using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ArrayUtility=ICode.ArrayUtility;
using ICode.Actions;
using ICode.Conditions;

namespace ICode{
	public static class FsmUtility {

		public static ICodeBehaviour[] GetBehaviours(this GameObject gameObject){
			return gameObject.GetComponents<ICodeBehaviour> ();
		}

		public static ICodeBehaviour[] GetBehaviours(this GameObject gameObject, bool includeChildren){
			if (includeChildren) {
				return gameObject.GetComponentsInChildren<ICodeBehaviour> ();
			} else {
				return gameObject.GetBehaviours();
			}
		}

		public static ICodeBehaviour GetBehaviour(this GameObject gameObject){
			return gameObject.GetComponent<ICodeBehaviour> ();
		}

		public static ICodeBehaviour GetBehaviour(this GameObject gameObject, int group){
			ICodeBehaviour[] behaviorComponents = gameObject.GetComponents<ICodeBehaviour>();
			if (behaviorComponents != null && behaviorComponents.Length > 0) {
				for (int i = 0; i < behaviorComponents.Length; ++i) {
					if(behaviorComponents[i].group == group){
						return behaviorComponents[i];
					}
				}
			}
			return null;
		}

		public static ICodeBehaviour AddBehaviour(this GameObject gameObject, StateMachine stateMachine){
			ICodeBehaviour behaviour = gameObject.AddComponent<ICodeBehaviour> ();
			behaviour.stateMachine = stateMachine;
			behaviour.EnableStateMachine ();
			return behaviour;
		}

		public static ICodeBehaviour AddBehaviour(this GameObject gameObject, StateMachine stateMachine, int group, bool replaceIfExists){
			ICodeBehaviour behaviour = gameObject.GetBehaviour (group);
			if (behaviour != null && replaceIfExists) {
				behaviour.stateMachine=stateMachine;
				behaviour.EnableStateMachine();
			}else{
				behaviour = gameObject.AddBehaviour (stateMachine);
				behaviour.group = group;
			} 
			return behaviour;
		}

		public static Node Copy(Node original){
			Node dest = (Node)ScriptableObject.CreateInstance(original.GetType());
			dest.color = original.color;
			dest.comment = original.comment;
			dest.Name = original.Name;
			dest.position = original.position;
			dest.Parent = original.Parent;
			dest.hideFlags = original.hideFlags;
			dest.IsStartNode = original.IsStartNode;

			if (original is StateMachine) {
				StateMachine destFsm = dest as StateMachine;
				StateMachine origFsm = original as StateMachine;
				
				destFsm.Variables = CopyVariables (origFsm.Variables);
				destFsm.Nodes = CopyNodes (origFsm.Nodes, destFsm);
			} else if(original is State){
				State destState = dest as State;
				State origState = original as State;
				destState.IsSequence=origState.IsSequence;
				destState.Actions=CopyExecutableNodes<StateAction>(origState.Actions);
			}

			foreach (Transition origTransition in original.Transitions) {
				Node toNode=dest.Parent.Nodes.ToList().Find(x=>x.Name==origTransition.ToNode.Name);
				if(toNode != null){
					Transition destTrasition= ScriptableObject.CreateInstance<Transition>();
					destTrasition.hideFlags=HideFlags.HideInHierarchy;
					destTrasition.ToNode=toNode;
					destTrasition.FromNode=dest;
					destTrasition.Conditions=CopyExecutableNodes<Condition>(origTransition.Conditions);
					dest.Transitions=ArrayUtility.Add<Transition>(dest.Transitions,destTrasition);
				}
			}
			return dest;
		}

		private static Node[] CopyNodes(Node[] nodes, StateMachine parent){
			List<Node> mNodes= new List<Node>();
			foreach(Node original in nodes){
				Type nodeType=original.GetType();

				Node dest= (Node)ScriptableObject.CreateInstance(nodeType);
				dest.color = original.color;
				dest.comment = original.comment;
				dest.Name = original.Name;
				dest.Parent = parent;
				dest.position = original.position;
				dest.IsStartNode=original.IsStartNode;
				dest.hideFlags=HideFlags.HideInHierarchy;

				if(typeof(State).IsAssignableFrom(nodeType)){
					State state = dest as State;
					state.IsSequence=(original as State).IsSequence;
					state.Actions=CopyExecutableNodes<StateAction>((original as State).Actions);
				}else{
					StateMachine stateMachine=dest as StateMachine;
					stateMachine.Nodes=CopyNodes((original as StateMachine).Nodes,stateMachine);
				}
				mNodes.Add(dest);
			}

			foreach (Node original in nodes) {
				foreach (Transition origTransition in original.Transitions) {
					Transition destTrasition= ScriptableObject.CreateInstance<Transition>();
					Node dest=mNodes.Find(x=>x.Name==original.Name);
					destTrasition.hideFlags=HideFlags.HideInHierarchy;
					destTrasition.ToNode=mNodes.ToList().Find(x=>x.Name==origTransition.ToNode.Name);
					destTrasition.FromNode=dest;
					destTrasition.Conditions=CopyExecutableNodes<Condition>(origTransition.Conditions);
					dest.Transitions=ArrayUtility.Add<Transition>(dest.Transitions,destTrasition);
				}		
			}

			return mNodes.ToArray();
		}

		public static ExecutableNode Copy(ExecutableNode original){
			ExecutableNode destination = (ExecutableNode)ScriptableObject.CreateInstance(original.GetType());
			destination.name = original.name;
			destination.hideFlags = original.hideFlags;
			FieldInfo[] fields = original.GetType().GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			foreach (FieldInfo field in fields) {
				object value = field.GetValue (original);
				field.SetValue (destination, CopyFields(value));
			}
			return destination;
		}

		public static T[] CopyExecutableNodes<T>(ExecutableNode[] nodes){
			List<T> mNodes = new List<T> ();
			foreach(ExecutableNode node in nodes){
				ExecutableNode dest= (ExecutableNode)ScriptableObject.Instantiate(node);
				dest.hideFlags=HideFlags.HideInHierarchy;
				dest.name=node.name;
				FieldInfo[] fields = node.GetType().GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

				foreach (FieldInfo field in fields) {
					if(field.FieldType.IsSubclassOf(typeof(FsmVariable)) && field.GetValue(node) == null){
						FsmVariable variable = (FsmVariable)ScriptableObject.CreateInstance (field.FieldType);
						field.SetValue(node,variable);
					}
					object value = field.GetValue (node);
					field.SetValue (dest, CopyFields(value));
				}
				mNodes.Add((T)(object)dest);
			}
			return mNodes.ToArray();
		}



		private static object CopyFields(object source){
			if (source == null) {
				return null;			
			}	

			Type type=source.GetType();
			if (type.IsValueType || type == typeof(string) || type == typeof(GameObject) || typeof(UnityEngine.Object).IsAssignableFrom (type) && !typeof(FsmVariable).IsAssignableFrom (type)) {
				//	Debug.Log(source);
				return source;
			} else if (type.IsSubclassOf (typeof(ScriptableObject))) {
				//Debug.Log(source);
				ScriptableObject dest = ScriptableObject.CreateInstance (type);
				dest.hideFlags = HideFlags.HideInHierarchy;
				FieldInfo[] fields = type.GetFields (BindingFlags.Public | BindingFlags.Instance);
				foreach (FieldInfo field in fields) {
					object fieldValue = field.GetValue (source);
					if (fieldValue == null)
						continue;
					field.SetValue (dest, CopyFields (fieldValue));
				}
				PropertyInfo[] properties = type.GetProperties (BindingFlags.Public | BindingFlags.Instance);
				foreach (PropertyInfo property in properties) {
					if (!property.CanWrite) {
						continue;
					}
					object propertyValue = property.GetValue (source, null);
					if (propertyValue == null) {
						continue;
					}
					property.SetValue (dest, CopyFields (propertyValue), null);
				}
				return dest;
			} else if (type.IsArray) {
				var array = source as Array;
				Type elementType = type.GetElementType ();
				
				Array copied = Array.CreateInstance (elementType, array.Length);
				
				for (int i=0; i<array.Length; i++) {
					copied.SetValue (CopyFields (array.GetValue (i)), i);
				}
				return Convert.ChangeType (copied, source.GetType ());
			} else if (typeof(IList).IsAssignableFrom (type) && type.IsGenericType) {
				var array = source as IList;
				Type elementType = type.GetElementType ();
				if (elementType == null) {
					elementType = type.GetGenericArguments () [0];
				}
				var copied = (IList)typeof(List<>)
					.MakeGenericType (elementType)
						.GetConstructor (Type.EmptyTypes)
						.Invoke (null);
				
				for (int i=0; i<array.Count; i++) {
					copied.Add (CopyFields (array [i]));
				}
				return copied;
			}
			return null;
		}

		private static FsmVariable[] CopyVariables(FsmVariable[] variables){
			List<FsmVariable> mVariables= new List<FsmVariable>();
			foreach (FsmVariable variable in variables) {
				FsmVariable mVariable=(FsmVariable)ScriptableObject.Instantiate(variable);

				mVariable.hideFlags=HideFlags.HideInHierarchy;
				mVariables.Add(mVariable);	
			}
			return mVariables.ToArray ();
		}

        public static Node FindNode(StateMachine root, string name)
        {
			if (root.Name == name) {
				return root;		
			}
			Node[] nodes = root.NodesRecursive;
			for (int i = 0; i < (int)nodes.Length; i++)
			{
				Node node=nodes[i];
				if (node.Name == name)
				{
					return node;
				}
			}
			return null;
        }

        public static bool NodeExists(StateMachine stateMachine, string name)
        {
			StateMachine root = stateMachine.Root;
            if (FindNode(root, name) == null)
            {
                return false;
            }
            return true;
        }

		public static Type GetVariableType(Type type){
			if (type == null) {
				return null;			
			}else if (type == typeof(string)) {
				return typeof(FsmString);			
			} else if (type == typeof(bool)) {
				return typeof(FsmBool);
			} else if (type == typeof(Color)) {
				return typeof(FsmColor);
			} else if (type == typeof(float)) {
				return typeof(FsmFloat);
			} else if (type == typeof(GameObject)) {
				return typeof(FsmGameObject);
			} else if (typeof(UnityEngine.Object).IsAssignableFrom(type)) {
				return typeof(FsmObject);
			} else if (type == typeof(int)) {
				return typeof(FsmInt);
			} else if (type == typeof(Vector2)) {
				return typeof(FsmVector2);
			} else if (type == typeof(Vector3)) {
				return typeof(FsmVector3);
			}else if (typeof(IEnumerable).IsAssignableFrom(type)) {
				return typeof(FsmArray);
			} else {
				return null;
			}

		}

		public static T GetRandom<T>(this IList list){
			if (list != null && list.Count > 0) {
				return (T)list[UnityEngine.Random.Range(0,list.Count)];
			}	
			return default(T);
		}

		public static Vector3 GetPosition(FsmGameObject gameObject, FsmVector3 fsmVector3){
			Vector3 value;
			if (gameObject.Value == null) 
			{
				value = fsmVector3.Value;
			}
			else
			{
				value = (!fsmVector3.IsNone ? gameObject.Value.transform.TransformPoint(fsmVector3.Value) : gameObject.Value.transform.position);
			}
			return value;
		}

		public static T[] FindAll<T>(bool includeInactive)where T:Component{
			if (includeInactive) {
				UnityEngine.Object[] tempList = Resources.FindObjectsOfTypeAll (typeof(T));
				List<T> realList = new List<T> ();
				
				foreach (UnityEngine.Object obj in tempList) {
					if (obj is T) {
						if (obj.hideFlags == HideFlags.None)
							realList.Add ((T)obj);
					}
				}
				return realList.ToArray ();
			} else {
				return (T[])MonoBehaviour.FindObjectsOfType(typeof(T));			
			}
		}

		public static GameObject FindChild(this GameObject target, string name, bool includeInactive)
		{
			if (target != null) {
				if (target.name == name && includeInactive || target.name == name && !includeInactive && target.activeInHierarchy) {
					return target;
				}
				for (int i = 0; i < target.transform.childCount; ++i) {
					GameObject result = target.transform.GetChild (i).gameObject.FindChild ( name,includeInactive);
					
					if (result != null) 
						return result;
				}
			}
			return null;
		}

		public static GameObject FindClosestByName(this GameObject target, string name){
			Transform[] transforms=GameObject.FindObjectsOfType<Transform>();
			List<GameObject> gos=transforms.Select(x=>x.gameObject).Where(y=>y.name== name).ToList();
			
			GameObject closest=null; 
			float distance = Mathf.Infinity; 
			Vector3 position = target.transform.position; 
			foreach (GameObject go in gos)  { 
				Vector3 diff = (go.transform.position - position);
				float curDistance = diff.sqrMagnitude; 
				if (curDistance < distance && go.transform != target.transform) { 
					closest = go; 
					distance = curDistance; 
				} 
			} 
			return closest;
		}

		public static GameObject FindClosestByTag(this GameObject target, string tag){
			GameObject[] tagged=GameObject.FindGameObjectsWithTag(tag);
			GameObject closest=null; 
			float distance = Mathf.Infinity; 
			Vector3 position = target.transform.position; 
			foreach (GameObject go in tagged)  { 
				Vector3 diff = (go.transform.position - position);
				float curDistance = diff.sqrMagnitude; 
				if (curDistance < distance && go.transform != target.transform) { 
					closest = go; 
					distance = curDistance; 
				} 
			} 
			return closest;
		}

		public static bool CompareFloat(float first, float second, FloatComparer comparer){
			switch (comparer) {
			case FloatComparer.Less:
				return first < second;
			case FloatComparer.Greater:
				return first > second;
			case FloatComparer.Equal:
				return Mathf.Approximately(first,second);
			case FloatComparer.GreaterOrEqual:
				return first >= second;
			case FloatComparer.LessOrEqual:
				return first <= second;
			case FloatComparer.NotEqual:
				return !Mathf.Approximately(first,second);
			}
			return false;
		}
	}
}