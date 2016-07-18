using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("The distance between the agent's position and the destination on the current path.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-remainingDistance.html")]
	[System.Serializable]
	public class GetRemainingDistance : NavMeshAgentCondition {
		[Tooltip("Is the distance greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmFloat value;

		public override bool Validate ()
		{	
			return FsmUtility.CompareFloat(agent.remainingDistance,value.Value,comparer);
		}
	}
}