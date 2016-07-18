using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("(Logarithmic rolloff) MaxDistance is the distance a sound stops attenuating at. (Linear rolloff) MaxDistance is the distance where the sound is completely inaudible.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-maxDistance.html")]
	[System.Serializable]
	public class SetMaxDistance : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.maxDistance = value.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			audio.maxDistance= value.Value;
		}
	}
}