using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Mute/unmute the Audio Clip played by an Audio Source component on a Game Object.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-mute.html")]
	[System.Serializable]
	public class Mute : AudioSourceAction {
		[Tooltip("Check to mute, uncheck to unmute.")]
		public FsmBool mute;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.mute = mute.Value;
			Finish ();
		}
	}
}