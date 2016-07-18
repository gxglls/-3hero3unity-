using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Maximum movement speed when following a path.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-speed.html")]
	[System.Serializable]
	public class SetSpeed : NavMeshAgentAction {
		[Tooltip("The speed to set.")]
		public FsmFloat speed;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.speed = speed.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			agent.speed = speed.Value;
		}
	}
}