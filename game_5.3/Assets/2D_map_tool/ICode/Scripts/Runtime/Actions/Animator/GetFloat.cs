using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the value of a float parameter.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetFloat.html")]
	[System.Serializable]
	public class GetFloat : AnimatorAction {
		[Tooltip("The animator bool parameter name to set.")]
		public FsmString parameter;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int id;
		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
			DoGetFloat ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetFloat ();
		}

		private void DoGetFloat(){
			store.Value = animator.GetFloat (id);
		}
	}
}