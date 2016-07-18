using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the playback position in the recording buffer.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-playbackTime.html")]
	[System.Serializable]
	public class SetPlaybackTime : AnimatorAction {
		[Tooltip("Playback time to set.")]
		public FsmFloat playbackTime;
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
			animator.playbackTime = playbackTime.Value;
		}
	}
}