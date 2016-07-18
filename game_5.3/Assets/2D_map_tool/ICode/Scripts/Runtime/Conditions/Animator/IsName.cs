using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Does the name match the name of the active state in the animator controller?")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/AnimatorStateInfo.IsName.html")]
	[System.Serializable]

	public class IsName : AnimatorCondition {
		[Tooltip("The layer to test.")]
		public FsmInt layer;
		[Tooltip("The animator state to test.")]
		public FsmString stateName;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			AnimatorStateInfo stateInfo=animator.GetCurrentAnimatorStateInfo(layer.Value);
			return (stateInfo.IsName(stateName.Value) == equals.Value);
		
		}
	}
}