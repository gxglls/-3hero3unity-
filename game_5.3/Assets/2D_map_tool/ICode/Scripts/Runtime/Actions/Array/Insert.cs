using UnityEngine;
using System.Collections;
using ArrayUtlity=ICode.ArrayUtility;

namespace ICode.Actions.Array{
	[Category(Category.Array)]  
	[Tooltip("Adds an element at given index.")]
	[System.Serializable]
	public class Insert : ArrayAction {
		[Tooltip("Index to add at.")]
		public FsmInt index;
		[ParameterType]
		public FsmVariable element;

		public override void OnEnter ()
		{
			array.Value = ArrayUtlity.Insert<object> (array.Value, element.GetValue (), index.Value);
			Finish ();
		}	
	}
}