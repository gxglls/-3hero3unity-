using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAudioSource{
	[System.Serializable]
	public abstract class AudioSourceAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;

		protected AudioSource audio;

		public override void OnEnter ()
		{
			audio = gameObject.Value.GetComponent<AudioSource> ();
		}
	}
}