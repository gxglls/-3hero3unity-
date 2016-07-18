using UnityEngine;
using System;

namespace ICode.Conditions.UnityEvent{
	[Category(Category.Event)]  
	[Tooltip("Custom messages sended by StateMachine.SendEvent")]
	[System.Serializable]
	public class OnCustomEvent : Condition {
		[InspectorLabel("Event")]
		[Tooltip("Event that is received from StateMachine.SendEvent")]
		public FsmString _event;
		[Shared]
		[ParameterType]
		public FsmVariable parameter;

		private bool isTrigger;
		
		public override void OnEnter ()
		{
			this.Root.Owner.onReceiveEvent+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			this.Root.Owner.onReceiveEvent -= OnTrigger;
			isTrigger = false;
		}
		
		private void OnTrigger(string eventName,object parameter){
			if (_event.Value == eventName) {
				if(this.parameter != null){
					this.parameter.SetValue(parameter);
				}
				isTrigger = true;
			}
		}
		
		public override bool Validate ()
		{
			if (isTrigger) {
				isTrigger=false;	
				return true;
			}
			return isTrigger;
		}
	}
}