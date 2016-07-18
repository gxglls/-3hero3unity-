using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Maximum turning speed in (deg/s) while following a path.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/NavMeshAgent-angularSpeed.html")]
	[System.Serializable]
	public class SetAngularSpeed : NavMeshAgentAction {
		[Tooltip("The angular speed to set.")]
		public FsmFloat angularSpeed;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.angularSpeed = angularSpeed.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			agent.angularSpeed = angularSpeed.Value;
		}
	}
}