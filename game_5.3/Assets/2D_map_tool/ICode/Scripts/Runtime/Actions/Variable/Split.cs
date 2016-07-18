using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Separates strings.")]
	[HelpUrl("")]
	[System.Serializable]
	public class Split : StateAction {
		[Tooltip("The string to use.")]
		public FsmString value;
		public List<string> seperators;
		public StringSplitOptions options;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmArray store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			DoSplit ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSplit ();
		}

		private void DoSplit(){
			store.Value = value.Value.Split (seperators.ToArray (), options).Cast<object> ().ToArray (); 
		}
	}
}