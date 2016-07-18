using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.StateMachine)]
	[Tooltip("Restarts the active state.")]
	[System.Serializable]
	public class RestartState : StateAction {
		
		public override void OnEnter ()
		{
			if (this.Root.Owner.ActiveNode is State) {
				(this.Root.Owner.ActiveNode as State).Restart();
			}
			Finish ();
		}
	}
}