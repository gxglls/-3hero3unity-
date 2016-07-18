using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category("NavMeshAgent/Special")]
	[Tooltip("Updates the velocity of the NavMeshAgent with root motion data.")]
	[System.Serializable]
	public class SynchronizeAnimator : NavMeshAgentAction {
		[Tooltip("Value to set.")]
		public FsmBool value;
		protected Transform transform;
		protected Animator animator;

		public override void OnEnter ()
		{
			base.OnEnter ();
			animator = gameObject.Value.GetComponent<Animator> ();
			transform = gameObject.Value.transform;
			AnimatorMoveProxy proxy = gameObject.Value.GetComponent<AnimatorMoveProxy> ();
			if (proxy == null) {
				proxy = gameObject.Value.AddComponent<AnimatorMoveProxy>();			
			}
			proxy.onAnimatorMove += OnAnimatorMove;
		}
		
		private void OnAnimatorMove ()
		{
			agent.updateRotation = !value.Value;
			if (value.Value) {
				transform.rotation=animator.rootRotation;
				if(agent != null){
					agent.velocity = animator.deltaPosition / Time.deltaTime;
				}
			}
		}
	}
}