using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Should root motion be applied?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-applyRootMotion.html")]
	[System.Serializable]
	public class ApplyRootMotion : AnimatorAction {
		[Tooltip("Value to set.")]
		public FsmBool value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.applyRootMotion = value;
			Finish ();
		}
		
	}
}