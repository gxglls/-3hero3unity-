using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Sets or updates the destination thus triggering the calculation for a new path.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent.SetDestination.html")]
	[System.Serializable]
	public class SetDestination : NavMeshAgentAction {
		[NotRequired]
		[Tooltip("The destination to set.")]
		public FsmVector3 destination;
		[SharedPersistent]
		[NotRequired]
		[Tooltip("Optional sets to targets position.")]
		public FsmGameObject target;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.Resume ();
			agent.updatePosition = true;
			DoSetDestination ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetDestination ();
		}

		private void DoSetDestination(){
			agent.SetDestination (FsmUtility.GetPosition(target,destination));
		}
	}
}