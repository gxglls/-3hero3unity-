using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Number of cascades to use for directional light shadows.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-shadowCascades.html")]
	[System.Serializable]
	public class SetShadowCascades : StateAction {
		public FsmInt cascades;
		
		public override void OnEnter ()
		{
			QualitySettings.shadowCascades = cascades.Value;
			Finish ();
		}
	}
}