using UnityEngine;
using System.Collections;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Reverse the array.")]
	[System.Serializable]
	public class Reverse : ArrayAction {
		public override void OnEnter ()
		{
			array.Value = ArrayUtility.Reverse<object> (array.Value);
			Finish ();
		}
	}
}