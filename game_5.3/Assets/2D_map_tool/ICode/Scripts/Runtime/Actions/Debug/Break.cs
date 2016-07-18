using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Debug)]
	[Tooltip("Pauses the editor.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Debug.Break.html")]
	[System.Serializable]
	public class Break : StateAction {
		public override void OnEnter ()
		{
			Debug.Log ("Break");
			Debug.Break ();
			Finish ();
		}
	}
}
