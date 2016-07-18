using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Compares two int values.")]
	[System.Serializable]
	public class CompareInt : Condition {
		[Shared]
		[Tooltip("Parameter to test.")]
		public FsmInt variable;
		[Tooltip("Is the variable greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmInt value;
		
		public override bool Validate ()
		{	
			return FsmUtility.CompareFloat(variable.Value,value.Value,comparer);
		}
	}
}