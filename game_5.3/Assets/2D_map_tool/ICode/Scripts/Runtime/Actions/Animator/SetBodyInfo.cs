using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Set body information e.g. bodyPosition and bodyRotation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-bodyPosition.html")]
	[System.Serializable]
	public class SetBodyInfo : AnimatorAction {
		[NotRequired]
		[Tooltip("The position of the body center of mass.")]
		public FsmVector3 bodyPosition;
		[NotRequired]
		[Tooltip("The rotation of the body center of mass.")]
		public FsmVector3 bodyRotation;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSetInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetInfo ();
		}

		private void DoSetInfo(){
			if (!bodyPosition.IsNone) {
				animator.bodyPosition = bodyPosition.Value;
			}
			if (!bodyRotation.IsNone) {
				animator.bodyRotation = Quaternion.Euler (bodyRotation.Value);
			}
		}
		
	}
}