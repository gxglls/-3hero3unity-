using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category("NavMeshAgent/Special")]
	[Tooltip("Patrol along waypoints.")]
	[System.Serializable]
	public class Patrol : NavMeshAgentAction {
		[Tooltip("Speed of the agent")]
		[DefaultValue(3.5f)]
		public FsmFloat speed;
		[Tooltip("Angular speed of the agent")]
		[DefaultValue(120.0f)]
		public FsmFloat angularSpeed;
		[Tooltip("The agent has arrived when the remaining distance is less then this value")]
		[DefaultValue(1.5f)]
		public FsmFloat threshold;
		[SharedPersistent]
		[Tooltip("Root GameObject, that has child transforms.")]
		public FsmGameObject waypointRoot;

		private List<Vector3> waypoints;
		private Transform rootTransform;
		private int waypointIndex=0;

		public override void OnEnter ()
		{
			base.OnEnter ();
			waypoints = new List<Vector3> ();
			rootTransform = ((GameObject)waypointRoot.Value).transform;

			foreach(Transform transform in rootTransform){
				waypoints.Add(transform.position);
			}

			float distance = Mathf.Infinity;
			float localDistance;
			for (int i = 0; i < waypoints.Count; ++i) {
				if ((localDistance = Vector3.Magnitude(agent.transform.position - waypoints[i])) < distance) {
					distance = localDistance;
					waypointIndex = i;
				}
			}
			agent.speed = speed.Value;
			agent.angularSpeed = angularSpeed.Value;
			agent.enabled = true;
			agent.Resume ();
			DoPatrol ();
		}
		
		public override void OnUpdate ()
		{
			DoPatrol ();
		}
		
		private void DoPatrol(){
			if (!agent.pathPending) {
				if (agent.remainingDistance < threshold.Value) {
					waypointIndex = (waypointIndex + 1) % waypoints.Count;
					agent.destination = waypoints[waypointIndex];
				}
			}
		}
		
	}
}