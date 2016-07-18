using UnityEngine;
using System.Collections;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Clear the array.")]
	[System.Serializable]
	public class Clear : ArrayAction {
		public override void OnEnter ()
		{
			System.Array.Clear(array.Value, 0, array.Value.Length);
			Finish ();
		}
		
		
	}
}