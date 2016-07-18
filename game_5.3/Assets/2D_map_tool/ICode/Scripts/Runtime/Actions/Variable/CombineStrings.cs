using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Variable)]   
	[Tooltip("Combines two strings into one.")]
	[HelpUrl("")]
	[System.Serializable]
	public class CombineStrings : StateAction {
		[Tooltip("The first string to use.")]
		public FsmString first;
		[Tooltip("The second string.")]
		public FsmString second;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmString store;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = first.Value + second.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = first.Value + second.Value;
		}
	}
}