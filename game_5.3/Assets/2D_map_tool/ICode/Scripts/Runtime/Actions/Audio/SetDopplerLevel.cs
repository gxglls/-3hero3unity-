using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Sets the Doppler scale for this AudioSource.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AudioSource-dopplerLevel.html")]
	[System.Serializable]
	public class SetDopplerLevel : AudioSourceAction {
		[Tooltip("Scale to set.")]
		public FsmFloat dopplerLevel;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			audio.dopplerLevel = dopplerLevel.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			audio.dopplerLevel= dopplerLevel.Value;
		}
	}
}