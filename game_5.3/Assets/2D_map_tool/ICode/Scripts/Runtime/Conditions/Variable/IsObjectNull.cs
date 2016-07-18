using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Checks if the Object value is null")]
	[System.Serializable]
	public class IsObjectNull : Condition {
		[Shared]
		[Tooltip("Parameter to test.")]
		public FsmObject variable;
		[Tooltip("Does the result equals this value.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return ((variable.Value == null)==equals.Value);			
		}
	}
}