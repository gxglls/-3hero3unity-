using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Sets how the AudioSource attenuates over distance.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-rolloffMode.html")]
	[System.Serializable]
	public class SetRolloffMode : AudioSourceAction {
		[Tooltip("Mode to set.")]
		public AudioRolloffMode mode;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.rolloffMode = mode;
			Finish ();
		}
	}
}