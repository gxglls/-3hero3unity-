using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a string value to a float value.")]
	[System.Serializable]
	public class StringToFloat : StateAction {
		[Shared]
		[Tooltip("String value to check.")]
		public FsmString value;
		[Shared]
		[Tooltip("Float value to store.")]
		public FsmFloat store;
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
			store.Value = float.Parse (value.Value);
		}
	}
}