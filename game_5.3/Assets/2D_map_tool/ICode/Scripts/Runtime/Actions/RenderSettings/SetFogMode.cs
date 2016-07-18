using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the fogg mode.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-fogMode.html")]
	[System.Serializable]
	public class SetFogMode : StateAction {
		[Tooltip("Fog mode to set.")]
		public FogMode mode;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fogMode = mode;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fogMode = mode;
		}
	}
}