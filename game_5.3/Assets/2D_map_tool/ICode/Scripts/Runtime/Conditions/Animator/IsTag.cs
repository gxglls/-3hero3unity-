using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Does tag match the tag of the active state in the animator controller.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/AnimatorStateInfo.IsTag.html")]
	[System.Serializable]
	public class IsTag : AnimatorCondition {
		[Tooltip("The layer to test.")]
		public FsmInt layer;
		[Tooltip("The tag to test.")]
		public FsmString tag;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			AnimatorStateInfo stateInfo=animator.GetCurrentAnimatorStateInfo(layer.Value);
			return (stateInfo.IsTag(tag.Value) == equals.Value);
			
		}
	}
}