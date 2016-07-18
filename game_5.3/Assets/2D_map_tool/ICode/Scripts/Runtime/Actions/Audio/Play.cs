using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Plays the clip with an optional certain delay.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.Play.html")]
	[System.Serializable]
	public class Play : AudioSourceAction {
		[Tooltip("Delay in seconds.")]
		public FsmFloat delay;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.PlayDelayed (delay.Value);
			Finish ();
		}
	}
}