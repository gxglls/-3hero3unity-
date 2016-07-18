using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Set a new animation clip.")]
	[System.Serializable]
	public class SetAnimationClip : AnimatorAction {
		[Tooltip("Old animation clip name.")]
		public FsmString oldClipName;
		[Tooltip("New animation clip to set.")]
		public FsmObject newClip;

		public override void OnEnter ()
		{
			base.OnEnter ();
			RuntimeAnimatorController myController = animator.runtimeAnimatorController;
			AnimatorOverrideController myOverrideController = new AnimatorOverrideController();
			myOverrideController.runtimeAnimatorController = myController;
			
			myOverrideController[oldClipName.Value] = newClip.Value as AnimationClip;
			animator.runtimeAnimatorController = myOverrideController;
			Finish ();
		}
	}
}