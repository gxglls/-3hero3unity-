using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Get touch input information.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input.GetTouch.html")]
	[System.Serializable]
	public class GetTouch: StateAction {
		[Tooltip("Touch index.")]
		public FsmInt fingerId;
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

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			DoGetTouchInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetTouchInfo ();
		}

		private void DoGetTouchInfo(){
			if (Input.touchCount > 0)
			{
				foreach (var touch in Input.touches)
				{
					if (touch.fingerId == fingerId.Value)
					{
						if(!position.IsNone)
							position.Value =touch.position;
						if(!deltaPosition.IsNone)
							deltaPosition.Value = touch.deltaPosition;
						if(!deltaTime.IsNone)
							deltaTime.Value = touch.deltaTime;
						if(!tapCount.IsNone)
							tapCount.Value = touch.tapCount;
					}
				}
			}
		}
	}
}