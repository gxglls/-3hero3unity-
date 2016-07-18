using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ICode;
using ICode.Conditions;
using ArrayUtility=ICode.ArrayUtility;
using System.Reflection;

namespace ICode.FSMEditor{
	public static class Pasteboard  {
		private static List<Node> nodes;

		static Pasteboard(){
			nodes = new List<Node> ();
		}

		public static void Copy(List<Node> nodes){
			Pasteboard.nodes = new List<Node>(nodes);
		}

		public static void Paste(Vector2 position, StateMachine stateMachine){
			List<Node> copiedNodes = new List<Node> ();
			Vector2 center = GetCenter (nodes);
	
			for (int i=0; i< nodes.Count; i++) {
				Node origNode=nodes[i];
				List<FsmVariable> sharedVariables= new List<FsmVariable>();
				GetSharedVariables(origNode,ref sharedVariables);
				if(sharedVariables.Count>0 ){
					string variableNames=string.Empty;
					sharedVariables.Select(x=>x.Name).ToList().ForEach(y=>variableNames=(variableNames+  (string.IsNullOrEmpty(variableNames)?"":",")+y));
					if( EditorUtility.DisplayDialog("Paste Variables","Copied states have reference to shared variables, do you want to paste those variables? ("+variableNames+")","Yes","No")){
						for(int j=0;j< sharedVariables.Count;j++){
							FsmVariable variable=sharedVariables[j];
							stateMachine.SetVariable(variable.Name,variable.GetValue());
						}
					}
				}

				Node mNode = (Node)FsmUtility.Copy(origNode);
				mNode.Parent = stateMachine;
				mNode.hideFlags = HideFlags.HideInHierarchy;
				if(mNode.IsStartNode && stateMachine.GetStartNode() != null){
					mNode.IsStartNode=false;
				}
				//mNode.Name = FsmEditorUtility.GenerateUniqueNodeName(mNode.GetType(),stateMachine);
				stateMachine.Nodes = ArrayUtility.Add<Node> (stateMachine.Nodes, mNode);

				mNode.position = new Rect(-(center.x-origNode.position.x)+position.x,-(center.y-origNode.position.y)+position.y,FsmEditorStyles.StateWidth,FsmEditorStyles.StateHeight);

				if (mNode.GetType () == typeof(StateMachine)) {
					mNode.position.width = FsmEditorStyles.StateMachineWidth;
					mNode.position.height = FsmEditorStyles.StateMachineHeight;
					
				}
				FsmEditorUtility.UpdateNodeColor (mNode);
				copiedNodes.Add(mNode);

			}

			for (int i=0; i< copiedNodes.Count; i++) {
				Node mNode = copiedNodes [i];
				if (mNode is AnyState) {
					bool mOverride=EditorUtility.DisplayDialog ("Override AnyState", "AnyState can only exist once per state machine. Do you want to override it?", "Yes", "No");
					AnyState anyState = stateMachine.Nodes.ToList().Find(x=>x.GetType() == typeof(AnyState) && (mOverride && x != mNode  || !mOverride && x==mNode)) as AnyState;
					stateMachine.Nodes = ArrayUtility.Remove (stateMachine.Nodes, anyState);
					FsmEditorUtility.DestroyImmediate (anyState);
					FsmEditor.SelectedNodes.Clear();
				}
			}

			for (int i=0; i< copiedNodes.Count; i++) {
				Node mNode=copiedNodes[i];

				foreach (Transition transition in mNode.Transitions) {	
					Node toNode=copiedNodes.Find(x=>x.Name==transition.ToNode.Name)?? stateMachine.Nodes.ToList().Find(x=>x.Name ==transition.ToNode.Name);
					if(toNode != null){
						transition.ToNode=toNode;
					}else{
						FsmEditorUtility.DestroyImmediate(transition);
						mNode.Transitions=ArrayUtility.Remove(mNode.Transitions,transition);

					}
				}
			}

			for (int i=0; i< copiedNodes.Count; i++) {
				Node mNode=stateMachine.Nodes.ToList().Find(x=>x.Name == copiedNodes[i].Name && x!=copiedNodes[i]);
				if(mNode != null)
					copiedNodes[i].Name = FsmEditorUtility.GenerateUniqueNodeName(copiedNodes[i].GetType(),stateMachine);
			}

			FsmEditorUtility.ParentChilds(stateMachine);
			nodes.Clear();
			EditorUtility.SetDirty (stateMachine);
		}

		private static Transition AddTransition(Node fromNode,Node toNode){
			if (fromNode == null || toNode == null || toNode.GetType () == typeof(AnyState)) {
				return null;
			}
			Transition transition= ScriptableObject.CreateInstance<Transition>();
			transition.hideFlags = HideFlags.HideInHierarchy;
			transition.Init(toNode,fromNode);
			if(EditorUtility.IsPersistent(fromNode)){
				AssetDatabase.AddObjectToAsset(transition,fromNode);
				AssetDatabase.SaveAssets();
			}
			fromNode.Transitions=ArrayUtility.Add<Transition>(fromNode.Transitions,transition);
			NodeInspector.Dirty ();	
			return transition;
		}

		private static Vector2 GetCenter(List<Node> nodes)
		{
			Vector2 center = Vector2.zero;
			for(int i=0;i< nodes.Count;i++){
				Node node=nodes[i];
				center += new Vector2 (node.position.center.x, node.position.center.y);
			}	
			center /= nodes.Count;
			return center;
		}

		public static void GetSharedVariables(Node node,ref List<FsmVariable> list){
			for (int i=0; i< node.Transitions.Length; i++) {
				for(int j=0;j<node.Transitions[i].Conditions.Length;j++){
					List<FsmVariable> mVariables=node.Transitions[i].Conditions[j].GetSharedVariables(node).ToList();
					for(int m=0;m<mVariables.Count;m++){
						if(!list.Contains(mVariables[m])){
							list.Add(mVariables[m]);
						}
					}
				}
			}

			if (typeof(State).IsAssignableFrom (node.GetType())) {
				State state = node as State;
				for(int i=0;i<state.Actions.Length;i++){
					List<FsmVariable> mVariables=state.Actions[i].GetSharedVariables(node).ToList();
					for(int m=0;m<mVariables.Count;m++){
						if(!list.Contains(mVariables[m])){
							list.Add(mVariables[m]);
						}
					}
				}
			} 
			if(typeof(StateMachine).IsAssignableFrom(node.GetType())){
				StateMachine stateMachine=node as StateMachine;
				for(int i=0;i< stateMachine.Nodes.Length;i++){
					GetSharedVariables(stateMachine.Nodes[i],ref list);
				}
			}
		} 

		public static bool CanPaste(){
			return Pasteboard.nodes.Count > 0;
		}
	}
}	