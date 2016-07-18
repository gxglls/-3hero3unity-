using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Projects the desired velocity of the NavMeshAgent with transforms forward vector.")]
	[System.Serializable]
	public class GetProjectedVelocity : NavMeshAgentAction {
		[NotRequired]
		[Shared]
		[Tooltip("The projected velocity.")]
		public FsmVector3 velocity;
		[NotRequired]
		[Shared]
		[Tooltip("The magnitude of the velocity.")]
		public FsmFloat magnitude;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
	
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetProjectedVelocity ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetProjectedVelocity ();
		}

		private void DoGetProjectedVelocity(){
			Vector3 vel = Vector3.Project (agent.desiredVelocity, agent.transform.forward);
			velocity.Value = vel;
			magnitude.Value = vel.magnitude;	
		}
	}
}