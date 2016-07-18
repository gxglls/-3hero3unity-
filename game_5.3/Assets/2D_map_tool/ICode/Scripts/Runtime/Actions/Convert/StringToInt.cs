using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.Convert)]
	[Tooltip("Converts a string value to an int value.")]
	[System.Serializable]
	public class StringToInt : StateAction {
		[Shared]
		[Tooltip("String value to check.")]
		public FsmString value;
		[Shared]
		[Tooltip("Int parameter to store.")]
		public FsmInt store;
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
			store.Value = int.Parse (value.Value);
		}
	}
}