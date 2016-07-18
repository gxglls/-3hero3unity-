using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Global multiplier for the LOD's switching distance.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-lodBias.html")]
	[System.Serializable]
	public class SetLodBias : StateAction {
		public FsmFloat lodBias;
		
		public override void OnEnter ()
		{
			QualitySettings.lodBias = lodBias.Value;
			Finish ();
		}
	}
}