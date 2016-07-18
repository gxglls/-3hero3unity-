using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ICode.Actions;
using System.Reflection;

namespace ICode{
	[System.Serializable]
	public class State:Node {
		[SerializeField]
		private bool isSequence;
		public bool IsSequence{
			get{
				return isSequence;
			}
			set{
				isSequence=value;
			}
		}

		[SerializeField]
		private StateAction[] actions= new StateAction[0];
		public StateAction[] Actions{
			get{
				return this.actions;
			}
			set{
				this.actions=value;
			}
		}


		private StateAction activeAction;
		public StateAction ActiveAction{
			get{
				return this.activeAction;
			}
		}

		private int activeActionIndex;
		private List<StateAction> activeActions;

		public override void OnEnter ()
		{
			base.OnEnter ();
			activeActions = new List<StateAction> (Actions.Where(action=>action.IsEnabled));
			for (int i=0; i< activeActions.Count; i++) {
				StateAction action = activeActions [i];
				action.Init(this);	
				action.OnEnterState();
			}
		}

		public override void OnExit ()
		{
			base.OnExit ();
			for(int i=0;i< actions.Length;i++){
				StateAction action=actions[i];
				if(action.IsEnabled && action.IsEntered){
					action.OnExit();
					action.Reset();	
				}
			}
			activeActionIndex = 0;
		}

		public override void OnUpdate ()
		{
			if (restart) {
				this.OnExit ();
				this.OnEnter ();
				restart=false;
			}
			if (this.IsSequence && activeActionIndex < activeActions.Count) {
				activeAction = activeActions [activeActionIndex];
				if (!activeAction.IsEntered) {
					activeAction.IsEntered = true;
					activeAction.OnEnter ();
				} else if (!activeAction.IsFinished) {
					activeAction.OnUpdate ();
				}
				
				if (activeAction.IsFinished) {
					activeActionIndex += 1;
				}
				if(activeActionIndex == activeActions.Count){
					this.Owner.SendEvent("FINISHED",null);
				}
			} else {
				for (int i=0; i<activeActions.Count; i++) {
					activeAction = activeActions [i];
					//Debug.Log(activeAction);
					if (!activeAction.IsEntered) {
						activeAction.IsEntered = true;
						activeAction.OnEnter ();
					} else if (!activeAction.IsFinished) {
						activeAction.OnUpdate ();
					}
				}
			}
		}

		private bool restart=false;
		public void Restart(){
			restart = true;
		}
	}
}