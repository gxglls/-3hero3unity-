using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Sets the spread angle a 3d stereo or multichannel sound in speaker space.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-spread.html")]
	[System.Serializable]
	public class SetSpread : AudioSourceAction {
		[Tooltip("Value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.spread= value.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			audio.spread= value.Value;
		}
	}
}