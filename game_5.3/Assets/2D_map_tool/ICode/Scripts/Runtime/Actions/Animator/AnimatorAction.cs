using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[RequireComponent(typeof(Animator))]
	[System.Serializable]
	public abstract class AnimatorAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;

		protected Animator animator;

		public override void OnEnter ()
		{
			animator = gameObject.Value.GetComponent<Animator> ();
		}
	}
}