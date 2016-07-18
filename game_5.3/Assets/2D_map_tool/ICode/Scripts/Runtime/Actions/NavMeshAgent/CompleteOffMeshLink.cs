using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Follow the current OffMeshLink.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/NavMeshAgent.CompleteOffMeshLink.html")]
	[System.Serializable]
	public class CompleteOffMeshLink : NavMeshAgentAction {
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			agent.CompleteOffMeshLink ();
			Finish ();
		}
	}
}