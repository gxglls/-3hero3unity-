using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the animator in recording mode, and allocates a circular buffer of size frameCount.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.StartRecording.html")]
	[System.Serializable]
	
	public class StartRecording : AnimatorAction {
		[Tooltip("The number of frames (updates) that will be recorded. If frameCount is 0, the recording will continue until the user calls StopRecording. The maximum value for frameCount is 10000.")]
		public FsmInt frameCount;
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.StartRecording (frameCount.Value);
			Finish ();
		}
	}
}