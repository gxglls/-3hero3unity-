using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Number of touches. Guaranteed not to change throughout the frame.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input-touchCount.html")]
	[System.Serializable]
	public class GetTouchCount : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Input.touchCount;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Input.touchCount;	
		}
	}
}