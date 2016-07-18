using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Does the variable starts with a value.")]
	[System.Serializable]
	public class IsStringStartWith : Condition {
		[Shared]
		[Tooltip("Target string variable to test.")]
		public FsmString variable;
		[Tooltip("Start string sequence to test with.")]
		public FsmString startWith;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return variable.Value.StartsWith (startWith.Value)== equals.Value;
		}
	}
}