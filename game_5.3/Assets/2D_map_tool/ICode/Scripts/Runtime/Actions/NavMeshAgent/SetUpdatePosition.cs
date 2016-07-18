using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Should the agent update the transform position?")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-updatePosition.html")]
	[System.Serializable]
	public class SetUpdatePosition : NavMeshAgentAction {
		[Tooltip("The value to set.")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.updatePosition = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			agent.updatePosition = value.Value;
		}
	}
}