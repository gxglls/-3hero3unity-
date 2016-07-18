using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to a Vector2 value.")]
	[System.Serializable]
	public class BoolToVector2 : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("Vector2 parameter to store.")]
		public FsmVector2 store;
		[Tooltip("Vector2 if value is true.")]
		public FsmVector2 trueVector;
		[Tooltip("Vector2 if value is false.")]
		public FsmVector2 falseVector;
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
			store.Value = value.Value ? trueVector.Value : falseVector.Value;
		}
	}
}