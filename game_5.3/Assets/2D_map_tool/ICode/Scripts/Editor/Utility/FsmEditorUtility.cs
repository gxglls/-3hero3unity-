using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICode;
using ICode.Actions;
using System.Reflection;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public static class FsmEditorUtility {
		public static void AddAction(StateAction action, State state){
			state.Actions = ArrayUtility.Add<StateAction> (state.Actions, action);
			if (EditorUtility.IsPersistent (state)) {
				AssetDatabase.AddObjectToAsset(action,state);
				AssetDatabase.SaveAssets();
			}
		} 

		public static void DestroyImmediate(ScriptableObject obj){
			if (obj == null) {
				return;			
			}
			FsmEditorUtility.DeleteChilds (obj);
			UnityEngine.Object.DestroyImmediate (obj, true);
			AssetDatabase.SaveAssets ();
		}

		public static void DeleteNode(Node node){
			FsmEditorUtility.DestroyImmediate (node);
			node.Parent.Nodes = ArrayUtility.Remove<Node> (node.Parent.Nodes, node);
			foreach (Transition transition in node.InTransitions) {
				FsmEditorUtility.DestroyImmediate(transition);	
				transition.FromNode.Transitions=ArrayUtility.Remove(transition.FromNode.Transitions,transition);
			}
			ErrorChecker.CheckForErrors ();
		}


		public static T AddNode<T>(Vector2 position, StateMachine parent){
			if (parent == null) {
				Debug.LogWarning("Can't add node to parent state machine, because the parent state machine is null!");
				return default(T);			
			}
			Node node = (Node)ScriptableObject.CreateInstance(typeof(T));
			node.hideFlags = HideFlags.HideInHierarchy;

			node.Name = FsmEditorUtility.GenerateUniqueNodeName<T> (parent.Root);
			node.Parent = parent;
			parent.Nodes =ArrayUtility.Add<Node> (parent.Nodes, node);

			node.position = new Rect(position.x,position.y,FsmEditorStyles.StateWidth,FsmEditorStyles.StateHeight);
			UpdateNodeColor (node);

			if (EditorUtility.IsPersistent (parent)) {
				AssetDatabase.AddObjectToAsset(node,parent);
			}

			if(node.GetType () == typeof(StateMachine)){
				node.position.width = FsmEditorStyles.StateMachineWidth;
				node.position.height = FsmEditorStyles.StateMachineHeight;

				AnyState state = FsmEditorUtility.AddNode<AnyState> (FsmEditor.Center,(StateMachine)node);
				UpdateNodeColor(state);
				state.Name="Any State";
			}

			AssetDatabase.SaveAssets();
			return (T)(object)node;
		}

		public static void SetDefaultNode(Node node, StateMachine parent){
			if (parent == null || node == null || !parent.Nodes.Contains (node)) {
				return;		
			}
			foreach(Node mNode in parent.Nodes){
				if(mNode.IsStartNode){
					mNode.IsStartNode=false;
					UpdateNodeColor(mNode);
				}
			}
			node.IsStartNode=true;
			UpdateNodeColor (node);
		}

		public static void UpdateNodeColor(Node node){
			if (node is AnyState) {
				node.color = FsmEditorStyles.anyStateColor;			
			} else if (node.IsStartNode) {
				node.color = FsmEditorStyles.startNodeColor;
			} else if (node is StateMachine) {
				node.color = FsmEditorStyles.fsmColor;			
			} else {
				node.color=FsmEditorStyles.defaultNodeColor;			
			}	
		}

		public static void DeleteChilds(ScriptableObject root){
			if(root == null){
				return;
			}
			FieldInfo[] fields = root.GetType ().GetAllFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i=0; i<fields.Length; i++) {
				FieldInfo field=fields[i];
				if(field.HasAttribute(typeof(ReferenceAttribute))){
					continue;
				}
				if(field.FieldType.IsSubclassOf(typeof(ScriptableObject))){
					ScriptableObject value=(ScriptableObject)field.GetValue(root);
					if(value != null){
						DeleteChilds(value);
						UnityEngine.Object.DestroyImmediate(value,true);
						AssetDatabase.SaveAssets();
					}
				}else if (field.FieldType.IsArray) {
					var array = field.GetValue(root) as Array;
					Type elementType = field.FieldType.GetElementType();
					if(elementType.IsSubclassOf(typeof(ScriptableObject))){
						foreach(ScriptableObject value in array){
							if(value != null){
								DeleteChilds(value);
								UnityEngine.Object.DestroyImmediate(value,true);
								AssetDatabase.SaveAssets();
							}
						}
					}
				} 
			}
		}

		public static void ParentChilds(ScriptableObject root){
			if(!EditorUtility.IsPersistent(root)){
				return;
			}
			FieldInfo[] fields = root.GetType ().GetAllFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
			for (int i=0; i<fields.Length; i++) {
				FieldInfo field=fields[i];
				if(field.HasAttribute(typeof(ReferenceAttribute))){
					continue;
				}
				if(field.FieldType.IsSubclassOf(typeof(ScriptableObject))){
					ScriptableObject value=(ScriptableObject)field.GetValue(root);
					if(value != null){
						if(!AssetDatabase.IsSubAsset(value) && !EditorUtility.IsPersistent(value)){
							AssetDatabase.AddObjectToAsset(value,root);
							AssetDatabase.SaveAssets();
						}
						ParentChilds(value);
					}
				}else if (field.FieldType.IsArray) {
					var array = field.GetValue(root) as Array;
					Type elementType = field.FieldType.GetElementType();
					if(elementType.IsSubclassOf(typeof(ScriptableObject))){
						foreach(ScriptableObject value in array){
							if(value != null){
								if(!AssetDatabase.IsSubAsset(value) && !EditorUtility.IsPersistent(value)){
									AssetDatabase.AddObjectToAsset(value,root);
									AssetDatabase.SaveAssets();
								}
								ParentChilds(value);
							}
						}
					}
				} 
			}
		}

		public static EventType ReserveEvent(params Rect[] areas){
			EventType eventType = Event.current.type;
			foreach(Rect area in areas){
				if((area.Contains(Event.current.mousePosition) && (eventType == EventType.MouseDown || eventType == EventType.ScrollWheel))){
					Event.current.type=EventType.Ignore;
				}
			}
			return eventType;
		}
		
		public static void ReleaseEvent(EventType type){
			if (Event.current.type != EventType.Used) {
				Event.current.type = type;
			}
		}

		public static string GenerateUniqueNodeName<T>(StateMachine stateMachine)
		{
			return GenerateUniqueNodeName (typeof(T), stateMachine);
		}

		public static string GenerateUniqueNodeName(Type type, StateMachine stateMachine)
		{
			int cnt = 0;
			string uniqueName = (type ==typeof(State)?"State":"FSM");
			
			while (FsmUtility.NodeExists(stateMachine.Root,uniqueName+" "+cnt.ToString())) {
				cnt++;	
			}
			return uniqueName + " " + cnt.ToString ();
		}

		public static List<T> FindInScene<T> () where T : Component
		{
			T[] comps = Resources.FindObjectsOfTypeAll(typeof(T)) as T[];
			
			List<T> list = new List<T>();
			
			foreach (T comp in comps)
			{
				if (comp.gameObject.hideFlags == 0)
				{
					string path = AssetDatabase.GetAssetPath(comp.gameObject);
					if (string.IsNullOrEmpty(path)) list.Add(comp);
				}
			}
			return list;
		}
	}
}