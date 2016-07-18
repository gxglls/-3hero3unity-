using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Time)]   
	[Tooltip("The scale at which the time is passing. This can be used for slow motion effects.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Time-timeScale.html")]
	[System.Serializable]
	public class SetTimeScale : StateAction {
		[Tooltip("Value to set.")]
		public FsmFloat timeScale;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			Time.timeScale = timeScale.Value;
			if (!everyFrame) {
				Finish();			
			}
		}	

		public override void OnUpdate ()
		{
			Time.timeScale = timeScale.Value;
		}
	}
}