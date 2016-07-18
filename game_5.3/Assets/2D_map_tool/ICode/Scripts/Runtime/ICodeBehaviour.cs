using UnityEngine;
using System.Linq;
using System.Collections;

namespace ICode{
	[AddComponentMenu("ICode/ICodeBehaviour")]
	public class ICodeBehaviour : MonoBehaviour {
		public StateMachine stateMachine;
		public bool enableOnStart=true;
		public bool showStateGizmos=false;
		public bool showSceneIcon = false;
		public int group;
		[Multiline(5)]
		public string description;
		public delegate void CustomEvent(string eventName, object parameter);
		public event CustomEvent onReceiveEvent;
		private Node actveNode;
		public Node ActiveNode{
			get{
				return this.actveNode;
			}
			set{
				this.actveNode=value;
			
			}
		}
		private AnyState anyState;
		public AnyState AnyState{
			get{
				return this.anyState;
			}
			set{
				this.anyState=value;
			}
		}
		private Node switchToNode;
		private bool isPaused;
		private bool isDisabled;

		private void OnEnable(){
			if (enableOnStart) {
				EnableStateMachine();
			}
		}

		private void Update(){
			if (isPaused || isDisabled) {
				return;			
			}
			if (ActiveNode != null) {
				if(!ActiveNode.IsEntered){
					ActiveNode.OnEnter();
				}else if(!ActiveNode.IsFinished){
					ActiveNode.OnUpdate();
					UpdateChanges(ActiveNode);
				}	
			}
			if (AnyState != null) {
				if(!AnyState.IsEntered){
					AnyState.OnEnter();
				}else if(!AnyState.IsFinished){
					AnyState.OnUpdate();
					UpdateChanges(AnyState);
				}	

			}
		}

		private void SwitchNode(Node toNode)
		{
			if (toNode == null){
				return;
			}
			
			if (ActiveNode != null) {
				ActiveNode.OnExit();	
			}
			ActiveNode = toNode;
			if(this.ActiveNode != null && this.ActiveNode.Parent != this.AnyState.Parent){
				this.AnyState.OnExit();
				this.AnyState=this.ActiveNode.Parent.GetAnyState();
				this.AnyState.OnEnter();
			}
			switchToNode = null;
			ActiveNode.OnEnter ();
		}

		private void UpdateChanges(Node node){
			switchToNode = node.ValidateTransitions ();
			SwitchNode (switchToNode);
		}

		public void EnableStateMachine(){
			if (stateMachine == null) {
				enabled=false;
				return;
			}
			if (!stateMachine.IsInitialized) {
				stateMachine = (StateMachine)FsmUtility.Copy (stateMachine);
				stateMachine.Init (this);
			}
			if (!isPaused) {
				this.ActiveNode = stateMachine.GetStartNode ();
				this.AnyState = stateMachine.GetAnyState ();
			}
			isPaused = false;
			isDisabled = false;
			enabled = true;
		}


		public void DisableStateMachine(bool pause){
			this.isPaused = pause;
			this.isDisabled = true;
		}

		public void SetNode(string nodeName){
			Node node=stateMachine.NodesRecursive.First (x => x.Name == nodeName);
			SwitchNode (node);
		}

		public void SetNode(Node node){
			SwitchNode (node);		
		}

		public void SendEvent(string eventName, object parameter){
			if (onReceiveEvent != null) {
				onReceiveEvent (eventName,parameter);
			}
		}

		public void EnableGroup( int group){
			ICodeBehaviour[] behaviours = gameObject.GetComponents<ICodeBehaviour> ();
			for (int i =0; i< behaviours.Length; i++) {
				if(behaviours[i].group== group){
					behaviours[i].enabled=true;
				}
			}
		}
	}
}