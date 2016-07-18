using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category("NavMeshAgent/Special")]
	[Tooltip("Wander arround a point.")]
	[System.Serializable]
	public class Wander : NavMeshAgentAction {
		[NotRequired]
		[Shared]
		[Tooltip("Start position to wander around.")]
		public FsmVector3 startPosition;
		[Tooltip("Speed of the agent")]
		[DefaultValueAttribute(3.5f)]
		public FsmFloat speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValueAttribute(120.0f)]
		public FsmFloat angularSpeed;
		[Tooltip("The agent has arrived when the remaining distance is less then this value")]
		[DefaultValueAttribute(0.5f)]
		public FsmFloat threshold;
		[Tooltip("How far away to wander from the current position")]
		[DefaultValueAttribute(20f)]
		public FsmFloat wanderDistance;
		[Tooltip("Turn rate.")]
		[DefaultValueAttribute(2.0f)]
		public FsmFloat turnRate;

		
		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.enabled = true;
			agent.Resume ();
			agent.destination = startPosition.IsNone?GetNextPosition():GetNextPositionWithin(startPosition.Value);
		}

		public override void OnUpdate ()
		{
			if (agent.remainingDistance < threshold.Value) {
				agent.destination = startPosition.IsNone?GetNextPosition():GetNextPositionWithin(startPosition.Value);
			}
		}

		private Vector3 GetNextPosition(){
			Vector3 direction = agent.transform.forward + Random.insideUnitSphere * turnRate.Value;
			return agent.transform.position + direction.normalized * wanderDistance.Value;
		}

		private Vector3 GetNextPositionWithin(Vector3 _startPos){
			Vector3	pos = _startPos + (Random.insideUnitSphere * Random.Range(1.0f, this.agent.radius));
			
			var dir = (pos - this.agent.transform.position);
			var dist = dir.magnitude;
			if (dist < this.wanderDistance)
			{
				pos = this.agent.transform.position + ((dir / dist) * this.wanderDistance);
			}	
			return pos;
		}


	}
}