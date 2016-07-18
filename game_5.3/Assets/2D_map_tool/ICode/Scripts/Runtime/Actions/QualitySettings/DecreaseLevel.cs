using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Decrease the current quality level.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings.DecreaseLevel.html")]
	[System.Serializable]
	public class DecreaseLevel : StateAction {
		[Tooltip("Should expensive changes be applied (Anti-aliasing etc).")]
		public FsmBool applyExpensiveChanges;
		
		public override void OnEnter ()
		{
			QualitySettings.DecreaseLevel (applyExpensiveChanges.Value);
			Finish ();
		}
	}
}