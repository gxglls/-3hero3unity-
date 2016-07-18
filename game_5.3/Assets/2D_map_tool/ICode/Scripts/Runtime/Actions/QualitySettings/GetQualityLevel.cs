using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityQualitySettings{
	[Category("QualitySettings")]
	[Tooltip("Returns the current graphics quality level.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/QualitySettings.GetQualityLevel.html")]
	[System.Serializable]
	public class GetQualityLevel : StateAction {
		[Shared]
		[Tooltip("Result quality index.")]
		public FsmInt storeIndex;
		
		public override void OnEnter ()
		{
			storeIndex.Value = QualitySettings.GetQualityLevel ();
			Finish ();
		}
	}
}