using UnityEngine;
using System.Collections;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Gets an element at index.")]
	[System.Serializable]
	public class GetElement : ArrayAction {
		public FsmInt index;
		[Shared]
		[ParameterType]
		public FsmVariable element;
		public override void OnEnter ()
		{
			element.SetValue (array.Value [index.Value]);
			Finish ();
		}
		
		
	}
}