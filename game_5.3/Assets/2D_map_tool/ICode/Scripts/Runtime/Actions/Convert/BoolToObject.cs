using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a bool value to an Object value.")]
	[System.Serializable]
	public class BoolToObject : StateAction {
		[Shared]
		[Tooltip("Bool value to check.")]
		public FsmBool value;
		[Shared]
		[Tooltip("Object parameter to store.")]
		public FsmObject store;
		[Tooltip("Object if value is true.")]
		public FsmObject trueObject;
		[Tooltip("Object if value is false.")]
		public FsmObject falseObject;
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
			store.Value = value.Value ? trueObject.Value : falseObject.Value;
		}
	}
}