using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Sets the default audio clip to play.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/AudioSource-clip.html")]
	[System.Serializable]
	public class SetAudioClip : AudioSourceAction {
		[Tooltip("The clip to set.")]
		public FsmObject clip;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.clip = (AudioClip)clip.Value;
			Finish ();
		}
	}
}