using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Should the agent move via OffMeshLinks automatically?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/NavMeshAgent-autoTraverseOffMeshLink.html")]
	[System.Serializable]
	public class SetAutoTraverseOffMeshLink : NavMeshAgentAction {
		[Tooltip("The value to set.")]
		public FsmBool value;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.autoTraverseOffMeshLink = value.Value;
			Finish ();
		}
	}
}