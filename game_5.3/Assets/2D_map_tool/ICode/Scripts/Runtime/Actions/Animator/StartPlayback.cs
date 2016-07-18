using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the animator in playback mode.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.StartPlayback.html")]
	[System.Serializable]
	public class StartPlayback : AnimatorAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.StartPlayback ();
			Finish ();
		}
	}
}