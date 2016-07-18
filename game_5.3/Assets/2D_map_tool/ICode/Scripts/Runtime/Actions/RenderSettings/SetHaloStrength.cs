using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the halo strength.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-haloStrength.html")]
	[System.Serializable]
	public class SetHaloStrength : StateAction {
		[Tooltip("Strength to set.")]
		public FsmFloat strength;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.haloStrength = strength.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.haloStrength = strength.Value;
		}
	}
}