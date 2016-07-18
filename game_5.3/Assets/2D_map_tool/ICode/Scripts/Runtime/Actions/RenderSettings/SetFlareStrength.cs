using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the flare strength.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-flareStrength.html")]
	[System.Serializable]
	public class SetFlareStrength : StateAction {
		[Tooltip("Strength to set.")]
		public FsmFloat strength;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.flareStrength = strength.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.flareStrength = strength.Value;
		}
	}
}