using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to an int value.")]
	[System.Serializable]
	public class BoolToInt : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("Int parameter to store.")]
		public FsmInt store;
		[Tooltip("Int if value is true.")]
		[DefaultValueAttribute(1)]
		public FsmInt trueInt;
		[Tooltip("Int if value is false.")]
		[DefaultValueAttribute(0)]
		public FsmInt falseInt;
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
			store.Value = value.Value ? trueInt.Value : falseInt.Value;
		}
	}
}