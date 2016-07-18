using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Compare the value of a float parameter.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.GetFloat.html")]
	[System.Serializable]
	public class GetFloat : AnimatorCondition {
		[Tooltip("The animator float parameter name to test.")]
		public FsmString parameter;
		[Tooltip("Is the parameter greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmFloat value;

		private int id;
		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
		}

		public override bool Validate ()
		{
			float floatValue = animator.GetFloat (id);
			return FsmUtility.CompareFloat(floatValue,value.Value,comparer);
		}
	}
}