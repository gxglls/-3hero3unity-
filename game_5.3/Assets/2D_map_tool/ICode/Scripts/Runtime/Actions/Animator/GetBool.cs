using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the value of a bool parameter.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetBool.html")]
	[System.Serializable]
	public class GetBool : AnimatorAction {
		[Tooltip("The animator bool parameter name to set.")]
		public FsmString parameter;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int id;

		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
			DoGetBool ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetBool ();
		}

		private void DoGetBool(){
			store.Value = animator.GetBool (id);
		}
	}
}