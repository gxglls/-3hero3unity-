using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Application)]    
	[Tooltip("Can the streamed level be loaded?")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application.CanStreamedLevelBeLoaded.html")]
	[System.Serializable]
	public class CanStreamedLevelBeLoaded : Condition {
		[Tooltip("The name of the level.")]
		public FsmString level;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return Application.CanStreamedLevelBeLoaded (level.Value)== equals.Value;	
		}
	}
}