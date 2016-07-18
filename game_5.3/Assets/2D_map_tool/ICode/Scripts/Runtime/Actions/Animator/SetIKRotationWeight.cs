using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the rotational weight of an IK goal (0 = rotation before IK, 1 = rotation at the IK goal).")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKRotationWeight.html")]
	[System.Serializable]
	public class SetIKRotationWeight : AnimatorIKAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Tooltip("The rotational weight.")]
		public FsmFloat value;

		public override void OnAnimatorIK (int layer)
		{
			animator.SetIKRotationWeight (goal, value.Value);
		}
	}
}