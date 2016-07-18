using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user releases the key identified by name.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input.GetKeyUp.html")]
	[System.Serializable]
	public class GetKeyUp : Condition {
		public KeyCode keyCode;
		
		public override bool Validate ()
		{
			return Input.GetKeyUp(keyCode);
		}
	}
}