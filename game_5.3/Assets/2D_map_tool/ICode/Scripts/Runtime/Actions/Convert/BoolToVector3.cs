using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to a Vector3 value.")]
	[System.Serializable]
	public class BoolToVector3 : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("Vector3 parameter to store.")]
		public FsmVector3 store;
		[Tooltip("Vector3 if value is true.")]
		public FsmVector3 trueVector;
		[Tooltip("Vector3 if value is false.")]
		public FsmVector3 falseVector;
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