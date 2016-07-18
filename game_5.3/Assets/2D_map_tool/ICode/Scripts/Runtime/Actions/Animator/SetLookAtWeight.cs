using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Set look at weights.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.SetLookAtWeight.html")]
	[System.Serializable]
	public class SetLookAtWeight : AnimatorIKAction {
		[Tooltip("(0-1) the global weight of the LookAt, multiplier for other parameters.")]
		public FsmFloat weight;
		[Tooltip("(0-1) determines how much the body is involved in the LookAt.")]
		public FsmFloat bodyWeight;
		[Tooltip("(0-1) determines how much the head is involved in the LookAt.")]
		public FsmFloat headWeight;
		[Tooltip("(0-1) determines how much the eyes is involved in the LookAt.")]
		public FsmFloat eyesWeight;
		[Tooltip("(0-1) 0.0 means the character is completely unrestrained in motion, 1.0 means he's completely clamped (look at becomes impossible), and 0.5 means he'll be able to move on half of the possible range (180 degrees).")]
		public FsmFloat clampWeight;

		public override void OnAnimatorIK (int layer)
		{
			animator.SetLookAtWeight (weight.Value,bodyWeight.Value,headWeight.Value,eyesWeight.Value,clampWeight.Value);
		}
	}
}