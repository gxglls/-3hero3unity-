using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Pauses playing the clip.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.Pause.html")]
	[System.Serializable]
	public class Pause : AudioSourceAction {

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.Pause ();
			Finish ();
		}
	}
}