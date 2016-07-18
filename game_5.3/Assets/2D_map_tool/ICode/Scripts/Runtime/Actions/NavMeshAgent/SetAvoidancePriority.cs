using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("The avoidance priority level.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/NavMeshAgent-avoidancePriority.html")]
	[System.Serializable]
	public class SetAvoidancePriority : NavMeshAgentAction {
		[Tooltip("Priority to set.")]
		public FsmInt priority;

		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.avoidancePriority = priority.Value;
			Finish ();
		}

	}
}