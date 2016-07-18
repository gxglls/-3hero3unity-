using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[Category(Category.AudioSource)]
	[Tooltip("Plays an AudioClip at a given position in world space.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/AudioSource.PlayClipAtPoint.html")]
	[System.Serializable]
	public class PlayClipAtPoint : StateAction {
		[Tooltip("Audio data to play.")]
		public FsmObject clip;
		[NotRequired]
		[Tooltip("Position in world space from which sound originates.")]
		public FsmVector3 position;
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Optional plays at targets position.")]
		public FsmGameObject target;
		[Tooltip("Playback volume.")]
		public FsmFloat volume;

		public override void OnEnter ()
		{
			base.OnEnter ();
			AudioSource.PlayClipAtPoint ((AudioClip)clip.Value, FsmUtility.GetPosition(target, position), volume.Value);
			Finish ();
		}
	}
}