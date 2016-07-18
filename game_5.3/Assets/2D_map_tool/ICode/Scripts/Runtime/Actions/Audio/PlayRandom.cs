using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Plays a random clip with an optional certain delay.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.Play.html")]
	[System.Serializable]
	public class PlayRandom : AudioSourceAction {
		public List<AudioClip> clips;
		[Tooltip("Delay in seconds.")]
		public FsmFloat delay;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.clip = clips.GetRandom<AudioClip>();
			audio.PlayDelayed (delay.Value);
			Finish ();
		}
	}
}