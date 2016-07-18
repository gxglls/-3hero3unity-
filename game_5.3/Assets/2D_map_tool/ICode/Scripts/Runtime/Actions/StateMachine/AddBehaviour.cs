using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.StateMachine)]
	[Tooltip("Adds a new ICodeBehaviour.")]
	[System.Serializable]
	public class AddBehaviour : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("StateMachine to add.")]
		public FsmObject stateMachine;
		[Tooltip("The group of the ICodeBehaviour.")]
		public FsmInt group;
		[Tooltip("Replace the StateMachine if ICodeBehaviour exists with this group.")]
		public FsmBool replaceIfExists;

		public override void OnEnter ()
		{
			gameObject.Value.AddBehaviour (stateMachine.Value as StateMachine, group.Value, replaceIfExists.Value);
			Finish ();
		}
	}
}