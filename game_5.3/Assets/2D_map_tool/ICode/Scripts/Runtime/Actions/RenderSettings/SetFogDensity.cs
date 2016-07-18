using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the density of the exponential fog.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-fogDensity.html")]
	[System.Serializable]
	public class SetFogDensity : StateAction {
		[Tooltip("Density to set.")]
		public FsmFloat density;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fogDensity = density.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fogDensity = density.Value;
		}
	}
}