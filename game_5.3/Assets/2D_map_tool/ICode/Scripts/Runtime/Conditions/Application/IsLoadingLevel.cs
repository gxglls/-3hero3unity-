using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Application)]    
	[Tooltip("Is some level being loaded?")] 
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application-isLoadingLevel.html")]
	[System.Serializable]
	public class IsLoadingLevel : Condition {
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return Application.isLoadingLevel== equals.Value;
		}
	}
}