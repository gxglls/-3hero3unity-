using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Compares two float values.")]
	[System.Serializable]
	public class CompareFloat : Condition {
		[Shared]
		[Tooltip("Parameter to test.")]
		public FsmFloat variable;
		[Tooltip("Float comparer.")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmFloat value;
		
		public override bool Validate ()
		{
			return FsmUtility.CompareFloat(variable.Value,value.Value,comparer);
		}
	}
}