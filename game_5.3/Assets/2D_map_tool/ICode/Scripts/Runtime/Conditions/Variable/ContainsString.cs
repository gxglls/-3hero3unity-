using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Returns a value indicating whether a specified substring occurs within this string.")]
	[System.Serializable]
	public class ContainsString : Condition {
		[Shared]
		[Tooltip("First parameter.")]
		public FsmString first;
		[Tooltip("Second parameter.")]
		public FsmString second;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return (first.Value.Contains(second.Value)== equals.Value);
		}
	}
}