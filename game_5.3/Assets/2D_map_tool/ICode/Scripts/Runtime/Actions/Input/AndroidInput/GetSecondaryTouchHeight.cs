using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category("Input/AndroidInput")]
	[Tooltip("Property indicating the height of the secondary touchpad.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AndroidInput-secondaryTouchHeight.html")]
	[System.Serializable]
	public class GetSecondaryTouchHeight : StateAction {
		[Tooltip("Store the result")]
		public FsmInt store;

		public override void OnEnter ()
		{
			#if UNITY_ANDROID
			store.Value = AndroidInput.secondaryTouchHeight;
			#endif
			Finish ();
		}
	}
}