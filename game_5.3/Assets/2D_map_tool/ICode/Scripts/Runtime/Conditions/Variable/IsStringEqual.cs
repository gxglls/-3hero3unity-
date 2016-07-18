using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Is the first variable value equal to the second.")]
	[System.Serializable]
	public class IsStringEqual : Condition {
		[Shared]
		[Tooltip("First variable.")]
		public FsmString first;
		[Tooltip("Second variable.")]
		public FsmString second;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return (first.Value == second.Value)== equals.Value;
		}
	}
}