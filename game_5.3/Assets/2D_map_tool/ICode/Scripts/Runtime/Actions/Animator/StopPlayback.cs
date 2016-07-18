using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Stops the animator playback mode. When playback stops, the avatar resumes getting control from game logic.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.StopPlayback.html")]
	[System.Serializable]
	
	public class StopPlayback : AnimatorAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.StopPlayback ();
			Finish ();
		}
	}
}