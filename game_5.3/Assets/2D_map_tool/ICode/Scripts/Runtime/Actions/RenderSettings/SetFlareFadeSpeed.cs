using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the flare fade speed.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-flareFadeSpeed.html")]
	[System.Serializable]
	public class SetFlareFadeSpeed : StateAction {
		[Tooltip("Speed to set.")]
		public FsmFloat speed;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.flareFadeSpeed = speed.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.flareFadeSpeed = speed.Value;
		}
	}
}