using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Mute/unmute the Audio Clip played by an Audio Source component on a Game Object.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-bypassEffects.html")]
	[System.Serializable]
	public class SetBypass : AudioSourceAction {
		[Tooltip("Bypass effects (Applied from filter components or global listener filters).")]
		public FsmBool bypassEffects;
		public FsmBool bypassListenerEffects;
		public FsmBool bypassReverbZones;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.bypassEffects = bypassEffects.Value;
			audio.bypassListenerEffects = bypassListenerEffects.Value;
			audio.bypassReverbZones = bypassReverbZones.Value;
			Finish ();
		}
	}
}