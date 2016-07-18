using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Shadow drawing distance.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-shadowDistance.html")]
	[System.Serializable]
	public class SetShadowDistance : StateAction {
		public FsmFloat distance;
		
		public override void OnEnter ()
		{
			QualitySettings.shadowDistance = distance.Value;
			Finish ();
		}
	}
}