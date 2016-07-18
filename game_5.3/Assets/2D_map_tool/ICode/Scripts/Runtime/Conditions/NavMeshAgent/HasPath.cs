using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Does the agent currently have a path?")]
	[HelpUrl( "https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-hasPath.html")]
	[System.Serializable]
	public class HasPath : NavMeshAgentCondition {
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{	
			return agent.hasPath == equals.Value;
		}
	}
}