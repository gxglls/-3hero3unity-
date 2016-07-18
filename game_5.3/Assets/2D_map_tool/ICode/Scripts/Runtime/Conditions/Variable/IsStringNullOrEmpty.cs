using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Checks if the target string is null or empty.")]
	[System.Serializable]
	public class IsStringNullOrEmpty : Condition {
		[Shared]
		[Tooltip("Target string variable to test.")]
		public FsmString variable;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return string.IsNullOrEmpty(variable.Value)== equals.Value;
		}
	}
}