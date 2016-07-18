using UnityEngine;
using System.Collections;
using System;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Returns a copy of this string converted to uppercase.")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/ewdd6aed(v=vs.110).aspx")]
	[System.Serializable]
	public class ToUpper : StateAction {
		[Tooltip("The string to use.")]
		public FsmString value;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmString store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = value.Value.ToUpper ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.ToUpper ();
		}
	}
}