using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]
	[Tooltip("Enable or disable fog.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-fog.html")]
	[System.Serializable]
	public class EnableFog : StateAction {
		[Tooltip("True to enable fog.")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.fog = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.fog = value.Value;
		}
	}
}