using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Variable)]
	[Tooltip("Determines whether the end of this string instance matches the specified string.")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/2333wewz(v=vs.110).aspx")]
	[System.Serializable]
	public class IsStringEndWith : Condition {
		[Shared]
		[Tooltip("Target string variable to test.")]
		public FsmString variable;
		[Tooltip("End string sequence to test with.")]
		public FsmString endsWith;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return variable.Value.StartsWith (endsWith.Value)== equals.Value;
		}
	}
}