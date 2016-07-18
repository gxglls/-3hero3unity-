using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the rotation of an IK goal.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKRotation.html")]
	[System.Serializable]
	public class SetIKRotation : AnimatorIKAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Tooltip("The euler angles to set.")]
		public FsmVector3 euler;

		public override void OnAnimatorIK (int layer)
		{
			animator.SetIKRotation (goal, Quaternion.Euler(euler.Value));
		}
	}
}