using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category("Input/AndroidInput")]
	[Tooltip("Number of secondary touches. Guaranteed not to change throughout the frame.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AndroidInput-touchCountSecondary.html")]
	[System.Serializable]
	public class GetTouchCountSecondary : StateAction {
		[Tooltip("Store the result")]
		public FsmInt store;

		public override void OnEnter ()
		{
			#if UNITY_ANDROID
			store.Value = AndroidInput.touchCountSecondary;
			#endif
			Finish ();
		}
	}
}