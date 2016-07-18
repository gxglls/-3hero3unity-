using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("A trigger parameter is like a bool parameter, but the parameter is reset to false once the parameter has been consumed by a transition condition.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.ResetTrigger.html")]
	[System.Serializable]
	public class ResetTrigger : AnimatorAction {
		[Tooltip("The name of the parameter.")]
		public FsmString parameter;

		public override void OnEnter ()
		{
			base.OnEnter ();
			int id = Animator.StringToHash (parameter.Value);
			animator.ResetTrigger (id);
			Finish ();
		}
	}
}