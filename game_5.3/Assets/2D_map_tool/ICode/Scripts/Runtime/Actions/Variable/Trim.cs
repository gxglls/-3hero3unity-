using UnityEngine;
using System.Collections;
using System;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Removes all leading and trailing white-space characters from the current String object.")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/t97s7bs3(v=vs.110).aspx")]
	[System.Serializable]
	public class Trim : StateAction {
		[Tooltip("The string to use.")]
		public FsmString value;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmString store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = value.Value.Trim ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.Trim ();
		}
	}
}