using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimation{
	[System.Serializable]
	public abstract class AnimationAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		
		protected Animation animation;
		
		public override void OnEnter ()
		{
			animation = gameObject.Value.GetComponent<Animation> ();
		}
	}
}