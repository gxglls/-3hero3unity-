using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Debug)]
	[Tooltip("Plays system beep sound.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/EditorApplication.Beep.html")]
	[System.Serializable]
	public class Beep : StateAction {

		public override void OnEnter ()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.Beep();
			#endif
			Finish ();
		}
	}
}
