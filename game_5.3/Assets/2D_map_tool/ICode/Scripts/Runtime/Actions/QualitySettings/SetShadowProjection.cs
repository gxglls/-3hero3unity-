using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Directional light shadow projection.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-shadowProjection.html")]
	[System.Serializable]
	public class SetShadowProjection : StateAction {
		public ShadowProjection projection;
		
		public override void OnEnter ()
		{
			QualitySettings.shadowProjection = projection;
			Finish ();
		}
	}
}