using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderSettings{
	[Category(Category.RenderSettings)]   
	[Tooltip("Sets the global skybox.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RenderSettings-skybox.html")]
	[System.Serializable]
	public class SetSkybox : StateAction {
		[Tooltip("Skybox to set.")]
		public FsmObject skybox;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			RenderSettings.skybox = (Material)skybox.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			RenderSettings.skybox =(Material) skybox.Value;
		}
	}
}