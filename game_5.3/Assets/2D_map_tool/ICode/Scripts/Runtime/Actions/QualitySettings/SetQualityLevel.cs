using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Sets a new graphics quality level.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings.SetQualityLevel.html")]
	[System.Serializable]
	public class SetQualityLevel : StateAction {
		[Tooltip("Quality index to set.")]
		public FsmInt index;
		[Tooltip("Should expensive changes be applied (Anti-aliasing etc).")]
		public FsmBool applyExpensiveChanges;
		
		public override void OnEnter ()
		{
			QualitySettings.SetQualityLevel (index.Value, applyExpensiveChanges.Value);
			Finish ();
		}
	}
}