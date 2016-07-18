using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the value of a bool parameter.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.GetBool.html")]
	public class GetBool : AnimatorCondition {
		[Tooltip("The animator bool parameter name to test.")]
		public FsmString parameter;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		private int id;
		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
		}

		public override bool Validate ()
		{
			return animator.GetBool(id) == equals.Value;
		}
	}
}