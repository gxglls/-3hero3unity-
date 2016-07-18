using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Stops animator record mode.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.StopRecording.html")]
	[System.Serializable]
	public class StopRecording : AnimatorAction {
		[Shared]
		[NotRequired]
		[Tooltip("The recorder StartTime")]
		public FsmFloat recorderStartTime;
		[Shared]
		[NotRequired]
		[Tooltip("The recorder StopTime")]
		public FsmFloat recorderStopTime;

		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.StopRecording ();
			recorderStartTime.Value = animator.recorderStartTime;
			recorderStopTime.Value = animator.recorderStopTime;
			Finish ();
		}
	}
}