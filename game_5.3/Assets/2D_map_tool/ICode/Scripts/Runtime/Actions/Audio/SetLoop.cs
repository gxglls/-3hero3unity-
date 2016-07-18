using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("f you disable looping on a playing AudioSource the sound will stop after the end of the current loop.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-loop.html")]
	[System.Serializable]
	public class SetLoop : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FsmBool value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.loop = value.Value;
			Finish ();
		}
	}
}