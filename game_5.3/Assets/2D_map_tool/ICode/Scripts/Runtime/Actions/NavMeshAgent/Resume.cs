using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Resumes the movement along the current path after a pause.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/NavMeshAgent.Resume.html")]
	[System.Serializable]
	public class Resume : NavMeshAgentAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.Resume ();
			Finish ();
		}
	}
}