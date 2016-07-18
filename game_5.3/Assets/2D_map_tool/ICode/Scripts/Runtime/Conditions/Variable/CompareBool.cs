using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Compares if a bool parameter equals true or false.")]
	[System.Serializable]
	public class CompareBool : Condition {
		[Shared]
		[Tooltip("Parameter to test.")]
		public FsmBool variable;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return ((variable.Value == true) == equals.Value);
		}
	}
}