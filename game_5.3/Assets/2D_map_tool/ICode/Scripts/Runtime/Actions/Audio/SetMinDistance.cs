using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Within the Min distance the AudioSource will cease to grow louder in volume. Outside the min distance the volume starts to attenuate.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-minDistance.html")]
	[System.Serializable]
	public class SetMinDistance : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.minDistance = value.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			audio.minDistance= value.Value;
		}
	}
}