using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Get root information e.g. rootPosition and rootRotation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-rootPosition.html")]
	[System.Serializable]
	public class GetRootInfo : AnimatorAction {
		[Shared]
		[NotRequired]
		[Tooltip("The root position, the position of the game object.")]
		public FsmVector3 rootPosition;
		[Shared]
		[NotRequired]
		[Tooltip("The root rotation, the rotation of the game object.")]
		public FsmVector3 rootRotation;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetInfo ();
			if (!everyFrame){
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetInfo ();
		}
		
		private void DoGetInfo(){
			if (!rootPosition.IsNone) {
				rootPosition.Value = animator.rootPosition;
			}
			if (!rootRotation.IsNone) {
				rootRotation.Value = animator.rootRotation.eulerAngles;
			}
		}
	}
}