using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Get body information e.g. bodyPosition and bodyRotation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-bodyPosition.html")]
	[System.Serializable]
	public class GetBodyInfo : AnimatorAction {
		[Shared]
		[NotRequired]
		[Tooltip("The position of the body center of mass.")]
		public FsmVector3 bodyPosition;
		[Shared]
		[NotRequired]
		[Tooltip("The rotation of the body center of mass.")]
		public FsmVector3 bodyRotation;
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
			if (!bodyPosition.IsNone) {
				bodyPosition.Value = animator.bodyPosition;
			}
			if (!bodyRotation.IsNone) {
				bodyRotation.Value = animator.bodyRotation.eulerAngles;
			}
		}
	}
}