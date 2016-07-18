using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Global anisotropic filtering mode.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings-anisotropicFiltering.html")]
	[System.Serializable]
	public class SetAnisotropicFiltering : StateAction {
		public AnisotropicFiltering filtering;
		
		public override void OnEnter ()
		{
			QualitySettings.anisotropicFiltering = filtering;
			Finish ();
		}
	}
}