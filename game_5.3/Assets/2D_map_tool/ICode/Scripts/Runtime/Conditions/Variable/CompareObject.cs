using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Compares two Object values.")]
	[System.Serializable]
	public class CompareObject : Condition {
		[Shared]
		[Tooltip("Parameter to test.")]
		public FsmObject variable;
		[Tooltip("Value to test with.")]
		public FsmObject value;
		[Tooltip("Does the result equals this value.")]
		public FsmBool equals;

		public override bool Validate ()
		{
				return ((variable.Value == value.Value)==equals.Value);			
		}
	}
}