using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.StateMachine)]
	[Tooltip("Sends an event to all GameObjects in array. Can be checked in condition OnCustomEvent.")]
	[System.Serializable]
	public class SendEventToArray : StateAction {
		[Shared]
		[Tooltip("Array to use.")]
		public FsmArray array;
		[Tooltip("Send event also to children state machines.")]
		public FsmBool includeChildren;
		[InspectorLabel("Event")]
		[Tooltip("Event name to send.")]
		public FsmString _event;
		[ParameterType]
		public FsmVariable parameter;

		public override void OnEnter ()
		{
			for (int j=0; j<array.Value.Length; j++) {
				object mObject=array.Value[j];
				GameObject behaviorGameObject = null;
				if(mObject is GameObject){
					behaviorGameObject= mObject as GameObject;
				}else if(mObject is Component){
					behaviorGameObject = (mObject as Component).gameObject;
				}else if(mObject is MonoBehaviour){
					behaviorGameObject =(mObject as MonoBehaviour).gameObject;
				}

				var behaviorComponents = behaviorGameObject.GetBehaviours (includeChildren.Value);

				if (behaviorComponents != null && behaviorComponents.Length > 0) {
					for (int i = 0; i < behaviorComponents.Length; ++i) {
						if (parameter != null) {
							behaviorComponents [i].SendEvent (_event.Value, parameter.GetValue ());
						} else {
							behaviorComponents [i].SendEvent (_event.Value, null);
						}
					}

				}
			}
			Finish ();
		}
	}
}