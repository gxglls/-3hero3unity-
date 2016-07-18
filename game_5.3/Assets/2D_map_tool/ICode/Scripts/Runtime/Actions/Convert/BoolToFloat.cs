using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to a float value.")]
	[System.Serializable]
	public class BoolToFloat : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("Float parameter to store.")]
		public FsmFloat store;
		[Tooltip("Float if value is true.")]
		[DefaultValueAttribute(0.5f)]
		public FsmFloat trueFloat;
		[Tooltip("Float if value is false.")]
		public FsmFloat falseFloat;
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
			store.Value = value.Value ? trueFloat.Value : falseFloat.Value;
		}
	}
}