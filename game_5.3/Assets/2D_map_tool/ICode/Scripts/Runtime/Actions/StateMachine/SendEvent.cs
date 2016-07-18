using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.StateMachine)]
	[Tooltip("Sends an event to all attached state machines. Can be checked in condition OnCustomEvent.")]
	[System.Serializable]
	public class SendEvent : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Send event also to children state machines.")]
		public FsmBool includeChildren;
		[InspectorLabel("Event")]
		[Tooltip("Event name to send.")]
		public FsmString _event;
		[ParameterType]
		public FsmVariable parameter;

		public override void OnEnter ()
		{

			GameObject behaviorGameObject = gameObject.Value;
			if (behaviorGameObject != null) {
				// Find the correct behavior tree based on the grouping
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