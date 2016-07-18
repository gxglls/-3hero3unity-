using UnityEngine;
using System.Collections;
using System;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Converts a shared variable to string.")]
	[System.Serializable]
	public class ToString : StateAction {
		[ParameterType]
		[Tooltip("The variable to use.")]
		public FsmVariable value;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmString store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = value.GetValue().ToString();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = value.GetValue().ToString();
		}
	}
}