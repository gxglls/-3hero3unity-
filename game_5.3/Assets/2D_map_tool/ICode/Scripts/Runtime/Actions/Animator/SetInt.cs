using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the value of an integer parameter.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetInteger.html")]
	[System.Serializable]
	public class SetInt : AnimatorAction {
		[Tooltip("The animator int parameter name to set.")]
		public FsmString parameter;
		[Tooltip("The value to set.")]
		public FsmInt value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private int id;

		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
			DoSetInt ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetInt ();
		}

		private void DoSetInt(){
			animator.SetInteger (id, value.Value);
		}
	}
}