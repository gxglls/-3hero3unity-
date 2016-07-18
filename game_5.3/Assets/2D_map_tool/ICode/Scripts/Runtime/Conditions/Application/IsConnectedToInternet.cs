using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Application)]    
	[Tooltip("Is there a connection to the internet?")]
	[System.Serializable]
	public class IsConnectedToInternet : Condition {
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)==equals.Value;
		}

	}
}