using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[System.Serializable]
	public abstract class AnimatorIKAction : AnimatorAction {

		protected AnimatorIKProxy proxy;
		public override void OnEnterState ()
		{
			base.OnEnter ();
			proxy = gameObject.Value.GetComponent<AnimatorIKProxy> ();
			if (proxy == null) {
				proxy = gameObject.Value.AddComponent<AnimatorIKProxy>();			
			}
			proxy.onAnimatorIK += OnAnimatorIK;
		}

		public override void OnExit ()
		{
			base.OnExit ();
			proxy.onAnimatorIK -= OnAnimatorIK;
		}

		public virtual void OnAnimatorIK(int layer){}
	}
}