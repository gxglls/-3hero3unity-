using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Stops playing the clip.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource.Stop.html")]
	[System.Serializable]
	public class Stop : AudioSourceAction {

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.Stop ();
			Finish ();
		}
	}
}