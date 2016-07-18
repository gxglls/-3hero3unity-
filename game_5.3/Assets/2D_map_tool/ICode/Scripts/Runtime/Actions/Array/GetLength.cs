using UnityEngine;
using System.Collections;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Gets the length of the array array.")]
	[System.Serializable]
	public class GetLength : ArrayAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = array.Value.Length;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = array.Value.Length;
		}
	}
}