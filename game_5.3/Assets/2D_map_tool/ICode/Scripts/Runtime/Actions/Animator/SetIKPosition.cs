using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the position of an IK goal.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKPosition.html")]
	[System.Serializable]
	public class SetIKPosition : AnimatorIKAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[NotRequired]
		[Tooltip("The translative weight.")]
		public FsmFloat weight;
		[NotRequired]
		[Tooltip("The position in world space.")]
		public FsmVector3 position;
		[NotRequired]
		[Shared]
		[Tooltip("Optional sets to targets position.")]
		public FsmGameObject target;

		public override void OnAnimatorIK (int layer)
		{
			Do ();
		}

		private void Do(){
			if (!weight.IsNone) {
				animator.SetIKPositionWeight(goal,weight.Value);
			}
			animator.SetIKPosition (goal,FsmUtility.GetPosition(target,position));
		}
	}
}