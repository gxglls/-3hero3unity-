using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Is the specified AnimatorController layer in a transition.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.IsInTransition.html")]
	[System.Serializable]
	public class IsInTransition : AnimatorCondition {
		[Tooltip("The layer to test.")]
		public FsmInt layer;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return animator.IsInTransition(layer.Value) == equals.Value;
		}
	}
}