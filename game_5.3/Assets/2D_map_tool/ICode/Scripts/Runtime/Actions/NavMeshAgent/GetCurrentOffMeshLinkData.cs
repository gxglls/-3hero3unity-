using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityNavMeshAgent{
	[Category(Category.NavMeshAgent)]
	[Tooltip("Gets the data from current OffMeshLinkData.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/NavMeshAgent-currentOffMeshLinkData.html")]
	[System.Serializable]
	public class GetCurrentOffMeshLinkData : NavMeshAgentAction {
		[NotRequired]
		[Shared]
		[Tooltip("Is link active.")]
		public FsmBool activated;
		[NotRequired]
		[Shared]
		[Tooltip("Link start world position")]
		public FsmVector3 startPos;
		[NotRequired]
		[Shared]
		[Tooltip("Link end world position.")]
		public FsmVector3 endPos;
		[NotRequired]
		[Shared]
		[Tooltip("Link type specifier.")]
		public FsmString linkType;
		[NotRequired]
		[Shared]
		[Tooltip("Is link valid.")]
		public FsmBool valid;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetOffMeshLinkData ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetOffMeshLinkData ();
		}

		private void DoGetOffMeshLinkData(){
			OffMeshLinkData data = agent.currentOffMeshLinkData;
			if(!activated.IsNone)
				activated.Value = data.activated;
			if(!endPos.IsNone)
				endPos.Value=data.endPos;
			if(!linkType.IsNone)
				linkType.Value=data.linkType.ToString();
			if(!startPos.IsNone)
				startPos.Value=data.startPos;
			if(!valid.IsNone)
				valid.Value = data.valid;
		}
	}
}