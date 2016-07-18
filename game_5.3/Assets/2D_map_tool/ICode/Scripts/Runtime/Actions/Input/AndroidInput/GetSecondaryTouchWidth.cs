using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category("Input/AndroidInput")]
	[Tooltip("Property indicating the width of the secondary touchpad.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AndroidInput-secondaryTouchWidth.html")]
	[System.Serializable]
	public class GetSecondaryTouchWidth : StateAction {
		[Tooltip("Store the result")]
		public FsmInt store;

		public override void OnEnter ()
		{
			#if UNITY_ANDROID
			store.Value = AndroidInput.secondaryTouchWidth;
			#endif
			Finish ();
		}
	}
}