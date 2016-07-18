using UnityEngine;
using System.Collections;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Removes an element at given index.")]
	[System.Serializable]
	public class RemoveAt : ArrayAction {
		[Tooltip("Index to remove at.")]
		public FsmInt index;

		public override void OnEnter ()
		{
			array.Value = ArrayUtility.RemoveAt<object> (array.Value, index.Value);
			Finish ();
		}
		
		
	}
}