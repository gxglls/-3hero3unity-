using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a string value to an int value.")]
	[System.Serializable]
	public class Vector3ToVector2 : StateAction {
		[Shared]
		[Tooltip("Vector3 to use.")]
		public FsmVector3 vector3;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
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
			store.Value = vector3.Value;
		}
	}
}