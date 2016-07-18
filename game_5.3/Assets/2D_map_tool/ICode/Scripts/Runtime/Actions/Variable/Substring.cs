using UnityEngine;
using System.Collections;
using System;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Retrieves a substring from this instance. The substring starts at a specified character position and continues to the end of the string.")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/hxthx5h6(v=vs.110).aspx")]
	[System.Serializable]
	public class Substring : StateAction {
		[Tooltip("The string to use.")]
		public FsmString value;
		[Tooltip("The zero-based starting character position of a substring in this instance.")]
		public FsmInt startIndex;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmString store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = value.Value.Substring (startIndex.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.Substring (startIndex.Value);
		}
	}
}