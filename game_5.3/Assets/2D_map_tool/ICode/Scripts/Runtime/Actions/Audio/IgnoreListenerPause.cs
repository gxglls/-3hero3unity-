using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Allows AudioSource to play even though AudioListener.pause is set to true. This is useful for the menu element sounds or background music in pause menus.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-ignoreListenerPause.html")]
	[System.Serializable]
	public class IgnoreListenerPause : AudioSourceAction {
		[Tooltip("Check to ignore.")]
		public FsmBool value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.ignoreListenerPause = value.Value;
			Finish ();
		}
	}
}