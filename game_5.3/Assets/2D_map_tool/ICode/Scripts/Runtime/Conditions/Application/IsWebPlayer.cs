using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Application)]    
	[Tooltip("Is the current platform WebPlayer?")] 
	[System.Serializable]
	public class IsWebPlayer : Condition {
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return Application.isWebPlayer==equals.Value;
		}
		
	}
}