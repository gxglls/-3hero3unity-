using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Sets the AntiAliazing filter.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-antiAliasing.html")]
	[System.Serializable]
	public class SetAntiAliasing : StateAction {
		[Tooltip("The AntiAliazing filter can be set to either 0,2,4 or 8. This coresponds to the number of multisamples used per pixel.")]
		public FsmInt antiAliasing;
		
		public override void OnEnter ()
		{
			QualitySettings.antiAliasing = antiAliasing.Value;
			Finish ();
		}
	}
}