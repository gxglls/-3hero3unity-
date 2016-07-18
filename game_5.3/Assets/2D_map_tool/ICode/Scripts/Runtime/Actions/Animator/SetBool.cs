using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the value of a bool parameter.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetBool.html")]
	[System.Serializable]
	public class SetBool : AnimatorAction {
		[Tooltip("The animator bool parameter name to set.")]
		public FsmString parameter;
		[Tooltip("The value to set.")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int id;
		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
			DoSetBool ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetBool ();
		}

		private void DoSetBool(){
			animator.SetBool (id, value.Value);
		}
	}
}