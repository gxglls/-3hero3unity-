using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Plays an AudioClip, and scales the AudioSource volume by volumeScale.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.PlayOneShot.html")]
	[System.Serializable]
	public class PlayOneShot : AudioSourceAction {
		[Tooltip("The clip being played.")]
		public FsmObject clip;
		[Tooltip("The scale of the volume (0-1).")]
		public FsmFloat volumeScale;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.PlayOneShot ((AudioClip)clip.Value, volumeScale.Value);
			Finish ();
		}
	}
}