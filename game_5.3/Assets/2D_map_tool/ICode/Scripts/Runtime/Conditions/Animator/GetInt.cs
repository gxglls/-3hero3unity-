using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Compare the value of an int parameter.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Animator.GetInteger.html")]
	[System.Serializable]
	public class GetInt : AnimatorCondition {
		[Tooltip("The animator int parameter name to test.")]
		public FsmString parameter;
		[Tooltip("Is the parameter greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmInt value;
		
		private int id;

		public override void OnEnter ()
		{
			base.OnEnter ();
			id = Animator.StringToHash (parameter.Value);
		}
		
		public override bool Validate ()
		{
			int intValue = animator.GetInteger (id);
			return FsmUtility.CompareFloat(intValue,value.Value,comparer);
		}
	}
}