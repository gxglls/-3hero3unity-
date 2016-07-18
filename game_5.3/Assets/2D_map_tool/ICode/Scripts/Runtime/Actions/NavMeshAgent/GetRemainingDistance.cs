using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("The distance between the agent's position and the destination on the current path.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-remainingDistance.html")]
	[System.Serializable]
	public class GetRemainingDistance : NavMeshAgentAction {
		[Shared]
		[Tooltip("Result to store.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = agent.remainingDistance;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = agent.remainingDistance;
		}
	}
}