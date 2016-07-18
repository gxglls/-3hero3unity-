using UnityEngine;
using System.Collections;
using System;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Returns a new string in which all occurrences of a specified string in this instance are replaced with another specified string.")]
	[HelpUrl("http://msdn.microsoft.com/en-us/library/czx8s9ts(v=vs.110).aspx")]
	[System.Serializable]
	public class ReplaceString : StateAction {
		[Tooltip("The string to use.")]
		public FsmString value;
		[Tooltip("The string to be replaced.")]
		public FsmString oldValue;
		[Tooltip("The string to replace all occurrences of oldChar.")]
		public FsmString newValue;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmString store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = value.Value.Replace (oldValue.Value, newValue.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.Value.Replace (oldValue.Value, newValue.Value);
		}
	}
}