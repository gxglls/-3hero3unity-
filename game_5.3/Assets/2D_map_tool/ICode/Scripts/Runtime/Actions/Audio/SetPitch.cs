using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Sets the pitch of the audio source.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-pitch.html")]
	[System.Serializable]
	public class SetPitch : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.pitch = value.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			audio.pitch= value.Value;
		}
	}
}