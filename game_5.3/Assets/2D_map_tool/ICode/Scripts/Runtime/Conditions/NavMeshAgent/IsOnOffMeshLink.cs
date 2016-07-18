using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Is the agent currently positioned on an OffMeshLink?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/NavMeshAgent-isOnOffMeshLink.html")]
	[System.Serializable]
	public class IsOnOffMeshLink : NavMeshAgentCondition {
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{	
			return agent.isOnOffMeshLink == equals.Value;
		}
	}
}