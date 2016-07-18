using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Move a group of Agents in a formation.")]
	[System.Serializable]
	public class MoveInFormation : StateAction {
		[SharedPersistent]
		[Tooltip("GameObjects to use.")]
		public FsmArray gameObjects;
		public Formation formation;
		[NotRequired]
		[Tooltip("The destination to set.")]
		public FsmVector3 destination;
		[SharedPersistent]
		[NotRequired]
		[Tooltip("Optional sets to targets position.")]
		public FsmGameObject target;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private List<NavMeshAgent> agents;
		private int maxInRow;
		private NavMeshAgent master;

		public override void OnEnter ()
		{
			base.OnEnter ();
			agents = new List<NavMeshAgent> ();
			foreach (object obj in gameObjects.Value) {
				if(obj is GameObject){
					NavMeshAgent mAgent=(obj as GameObject).GetComponent<NavMeshAgent>();
					if(mAgent != null){
						agents.Add(mAgent);
					}
				}
			}
			maxInRow = Mathf.CeilToInt (Mathf.Sqrt (agents.Count));
			master = agents [0];
			SetDestination (FsmUtility.GetPosition (target, destination));
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			SetDestination (FsmUtility.GetPosition (target, destination));
		}

		private void SetDestination(Vector3 position){
			if (agents.Count < 1) {
				return;
			}
			master.SetDestination (position);

			int currentInRow = 1;
			int currentInColumn = 0;
			for (int i=1; i< agents.Count; i++) {
				NavMeshAgent mAgent=agents[i];
				mAgent.speed = master.speed*1.5f;
				mAgent.SetDestination(master.transform.position-master.transform.right*currentInRow*2-master.transform.forward*currentInColumn*2);
				currentInRow++;
				if(currentInRow == maxInRow){
					currentInRow = 0;
					currentInColumn++;
				}
			}
		}
	}

	public enum Formation{
		Quad
	}
}
