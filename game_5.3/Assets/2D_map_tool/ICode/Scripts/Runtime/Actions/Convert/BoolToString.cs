using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to a string value.")]
	[System.Serializable]
	public class BoolToString : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("String to store.")]
		public FsmString store;
		[Tooltip("String if value is true.")]
		[DefaultValueAttribute("True")]
		public FsmString trueString;
		[Tooltip("String if value is false.")]
		[DefaultValueAttribute("False")]
		public FsmString falseString;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			DoConvert ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoConvert ();
		}
		
		private void DoConvert(){
			store.Value = value.Value ? trueString.Value : falseString.Value;
		}
	}
}