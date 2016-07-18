using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[System.Serializable]
	public abstract class AnimatorMoveAction : AnimatorAction {
		protected AnimatorMoveProxy proxy;

		public override void OnEnter ()
		{
			base.OnEnter ();
			AnimatorMoveProxy proxy = gameObject.Value.GetComponent<AnimatorMoveProxy> ();
			if (proxy == null) {
				proxy = gameObject.Value.AddComponent<AnimatorMoveProxy>();			
			}
			proxy.onAnimatorMove += OnAnimatorMove;
		}

		public override void OnExit ()
		{
			base.OnExit ();
			proxy.onAnimatorMove -= OnAnimatorMove;
		}
		
		public virtual void OnAnimatorMove(){}
	}
}