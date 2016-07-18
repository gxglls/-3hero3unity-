using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the look at position.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetLookAtPosition.html")]
	[System.Serializable]
	public class SetLookAtPosition : AnimatorIKAction {
		[NotRequired]
		[Tooltip("The position to lookAt.")]
		public FsmVector3 position;
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Optional sets to targets position.")]
		public FsmGameObject target;

		public override void OnAnimatorIK (int layer)
		{
			animator.SetLookAtPosition (FsmUtility.GetPosition(target,position));
		}
	}
}