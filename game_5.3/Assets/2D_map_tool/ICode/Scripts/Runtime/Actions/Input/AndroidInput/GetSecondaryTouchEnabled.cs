using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category("Input/AndroidInput")]
	[Tooltip("Property indicating whether the system provides secondary touch input.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AndroidInput-secondaryTouchEnabled.html")]
	[System.Serializable]
	public class GetSecondaryTouchEnabled : StateAction {
		[Tooltip("Store the result")]
		public FsmBool store;

		public override void OnEnter ()
		{
			#if UNITY_ANDROID
			store.Value=AndroidInput.secondaryTouchEnabled;
			#endif
			Finish ();
		}
	}
}