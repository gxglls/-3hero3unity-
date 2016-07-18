using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("This makes the audio source not take into account the volume of the audio listener.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-ignoreListenerVolume.html")]
	[System.Serializable]
	public class IgnoreListenerVolume : AudioSourceAction {
		[Tooltip("Check to ignore.")]
		public FsmBool value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.ignoreListenerVolume = value.Value;
			Finish ();
		}
	}
}