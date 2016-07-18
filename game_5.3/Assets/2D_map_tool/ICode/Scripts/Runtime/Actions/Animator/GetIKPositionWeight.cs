using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the translative weight of an IK goal (0 = at the original animation before IK, 1 = at the goal).")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetIKPositionWeight.html")]
	[System.Serializable]
	public class GetIKPositionWeight : AnimatorAction {
		[Tooltip("The AvatarIKGoal that is set.")]
		public AvatarIKGoal goal;
		[Shared]
		[Tooltip("Store the translative weight.")]
		public FsmFloat store;
		
		public override void OnUpdate()
		{
			 store.Value=animator.GetIKPositionWeight (goal);
		}
	}
}