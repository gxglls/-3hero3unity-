using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category("NavMeshAgent/Special")]
	[Tooltip("Seek a target.")]
	[System.Serializable]
	public class Seek : NavMeshAgentAction {
		[SharedPersistent]
		[Tooltip("Target to seek.")]
		public FsmGameObject target;
		[Tooltip("Speed of the agent")]
		[DefaultValueAttribute(3.5f)]
		public FsmFloat speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValueAttribute(120.0f)]
		public FsmFloat angularSpeed;
		[Tooltip("The agent has arrived when the distance to target is less then this value")]
		[DefaultValueAttribute(1.5f)]
		public FsmFloat stoppingDistance;

		private Transform mTarget;
		private Vector3 lastTargetPosition;

		public override void OnEnter ()
		{
			base.OnEnter ();
			mTarget = ((GameObject)target.Value).transform;

			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.stoppingDistance = stoppingDistance.Value;
			agent.enabled = true;
			agent.Resume ();
			agent.destination = GetTargetPosition ();
		}
		
		public override void OnUpdate ()
		{
			agent.destination = GetTargetPosition (); 
		}

		private Vector3 GetTargetPosition(){
			if (mTarget != null) {
				lastTargetPosition=mTarget.position;			
			}
			return lastTargetPosition;
		}
		
	}
}