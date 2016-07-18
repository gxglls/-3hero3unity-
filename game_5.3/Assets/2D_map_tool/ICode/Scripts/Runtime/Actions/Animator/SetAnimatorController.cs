using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("The runtime representation of AnimatorController that controls the Animator.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-runtimeAnimatorController.html")]
	[System.Serializable]
	public class SetAnimatorController : AnimatorAction {
		public FsmObject animatorController;
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.runtimeAnimatorController = animatorController.Value as RuntimeAnimatorController;
			Finish ();
		}
		
	}
}