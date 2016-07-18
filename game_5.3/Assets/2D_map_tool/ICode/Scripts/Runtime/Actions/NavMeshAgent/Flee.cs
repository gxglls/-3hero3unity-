using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category("NavMeshAgent/Special")]
	[Tooltip("Flee from target.")]
	[System.Serializable]
	public class Flee : NavMeshAgentAction {
		[SharedPersistent]
		[Tooltip("Target to flee from.")]
		public FsmGameObject target;
		[Tooltip("Speed of the agent")]
		[DefaultValueAttribute(3.5f)]
		public FsmFloat speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValueAttribute(120.0f)]
		public FsmFloat angularSpeed;
		[Tooltip("The agent has fleed when the distance is greater then this value")]
		[DefaultValueAttribute(10.0f)]
		public FsmFloat fleedDistance;

		private Transform mTarget;


		public override void OnEnter ()
		{
			base.OnEnter ();
			mTarget = target.Value.transform;

			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.enabled = true;
			agent.Resume ();
			agent.destination = GetFleePosition ();
		}
		
		public override void OnUpdate ()
		{
			if (Vector3.Distance (agent.transform.position, mTarget.position) < fleedDistance.Value) {
				agent.destination = GetFleePosition (); 
			}
		}
		
		private Vector3 GetFleePosition(){
			return agent.transform.position + (agent.transform.position - mTarget.position).normalized * 5;
		}
		
	}
}