using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("The maximum number of pixel lights that should affect any object.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-pixelLightCount.html")]
	[System.Serializable]
	public class SetPixelLightCount : StateAction {
		public FsmInt pixelLightCount;
		
		public override void OnEnter ()
		{
			QualitySettings.pixelLightCount = pixelLightCount.Value;
			Finish ();
		}
	}
}