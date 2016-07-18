using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.StateMachine)]
	[Tooltip("Enable a state machine or reset it.")]
	[System.Serializable]
	public class EnableStateMachine : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The group value of the StateMachineBehaviour to enable.")]
		public FsmInt group;

		public override void OnEnter ()
		{
			GameObject behaviorGameObject = (GameObject)gameObject.Value;
			var behaviorComponents = behaviorGameObject.GetComponents<ICodeBehaviour>();
			if (behaviorComponents != null && behaviorComponents.Length > 0) {
				for (int i = 0; i < behaviorComponents.Length; ++i) {
					if(behaviorComponents[i].group==group.Value){
						behaviorComponents[i].EnableStateMachine();
					}
				}
				
			}
			Finish ();
		}
	}
}