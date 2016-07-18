using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("The volume of the audio source (0.0 to 1.0).")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-volume.html")]
	[System.Serializable]
	public class SetVolume : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.volume= value.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			audio.volume= value.Value;
		}
	}
}