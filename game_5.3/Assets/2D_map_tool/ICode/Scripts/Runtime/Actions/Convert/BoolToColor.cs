using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to a Color value.")]
	[System.Serializable]
	public class BoolToColor : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("Color parameter to store.")]
		public FsmColor store;
		[Tooltip("Color if value is true.")]
		public FsmColor trueColor;
		[Tooltip("Color if value is false.")]
		public FsmColor falseColor;
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
			store.Value = value.Value ? trueColor.Value : falseColor.Value;
		}
	}
}