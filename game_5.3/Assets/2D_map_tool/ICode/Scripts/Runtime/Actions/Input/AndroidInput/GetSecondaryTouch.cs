using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category("Input/AndroidInput")]
	[Tooltip("Returns object representing status of a specific touch on a secondary touchpad")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AndroidInput.GetSecondaryTouch.html")]
	[System.Serializable]
	public class GetSecondaryTouch : StateAction {
		[Tooltip("The index")]
		public FsmInt index;
		[NotRequired]
		[Shared]
		[Tooltip("Store the position.")]
		public FsmVector2 position;
		[NotRequired]
		[Shared]
		[Tooltip("Store the deltaPosition.")]
		public FsmVector2 deltaPosition;
		[NotRequired]
		[Shared]
		[Tooltip("Store the tap count.")]
		public FsmInt tapCount;
		[NotRequired]
		[Shared]
		[Tooltip("Store the delta time.")]
		public FsmFloat deltaTime;


		public override void OnEnter ()
		{
			#if UNITY_ANDROID
			Touch touch = AndroidInput.GetSecondaryTouch (index.Value);
			if(!position.IsNone)
				position.Value =touch.position;
			if(!deltaPosition.IsNone)
				deltaPosition.Value = touch.deltaPosition;
			if(!deltaTime.IsNone)
				deltaTime.Value = touch.deltaTime;
			if(!tapCount.IsNone)
				tapCount.Value = touch.tapCount;
			#endif
			Finish ();
		}
	}
}