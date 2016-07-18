using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.StateMachine)]
	[Tooltip("Sets a node as active.")]
	[System.Serializable]
	public class SetNode : StateAction {
		[Tooltip("The name of the state to set.")]
		public FsmString nodeName;

		public override void OnEnter ()
		{
			this.Root.Owner.SetNode(nodeName.Value);
			Finish ();
		}
	}
}