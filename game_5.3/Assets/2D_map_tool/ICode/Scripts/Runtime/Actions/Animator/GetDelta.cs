using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Get delta information e.g. deltaPosition and deltaRotation.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-deltaPosition.html")]
	[System.Serializable]
	public class GetDelta : AnimatorAction {
		[Shared]
		[NotRequired]
		[Tooltip("The position of the body center of mass.")]
		public FsmVector3 deltaPosition;
		[Shared]
		[NotRequired]
		[Tooltip("The rotation of the body center of mass.")]
		public FsmVector3 deltaRotation;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetInfo ();
		}

		private void DoGetInfo(){
			if (!deltaPosition.IsNone) {
				deltaPosition.Value = animator.deltaPosition;
			}
			if (!deltaRotation.IsNone) {
				deltaRotation.Value = animator.deltaRotation.eulerAngles;
			}
		}
	}
}