using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user starts pressing down the key identified by name.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html")]
	[System.Serializable]
	public class GetKeyDown : Condition {
		public KeyCode keyCode;
		
		public override bool Validate ()
		{
			return Input.GetKeyDown(keyCode);
		}
	}
}