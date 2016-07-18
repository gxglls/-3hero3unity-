using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the ending distance of linear fog.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-fogEndDistance.html")]
	[System.Serializable]
	public class SetFogEndDistance : StateAction {
		[Tooltip("Fog end distance to set.")]
		public FsmFloat endDistance;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fogEndDistance = endDistance.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fogEndDistance = endDistance.Value;
		}
	}
}