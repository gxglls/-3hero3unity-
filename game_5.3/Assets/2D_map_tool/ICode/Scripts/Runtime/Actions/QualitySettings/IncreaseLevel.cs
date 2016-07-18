using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Increase the current quality level.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings.IncreaseLevel.html")]
	[System.Serializable]
	public class IncreaseLevel : StateAction {
		[Tooltip("Should expensive changes be applied (Anti-aliasing etc).")]
		public FsmBool applyExpensiveChanges;
		
		public override void OnEnter ()
		{
			QualitySettings.IncreaseLevel (applyExpensiveChanges.Value);
			Finish ();
		}
	}
}