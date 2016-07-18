using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Debug)]
	[Tooltip("Clears errors from the developer console.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Debug.ClearDeveloperConsole.html")]
	[System.Serializable]
	public class ClearDeveloperConsole : StateAction {
		
		public override void OnEnter ()
		{
			Debug.ClearDeveloperConsole ();
			Finish ();
		}
	}
}
