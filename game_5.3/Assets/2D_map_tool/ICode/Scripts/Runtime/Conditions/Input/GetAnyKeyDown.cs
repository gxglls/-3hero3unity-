using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Input)]
	[Tooltip("Is any key or mouse button currently held down? ")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input-anyKey.html")]
	[System.Serializable]
	public class GetAnyKeyDown : Condition {

		public override bool Validate ()
		{
			return Input.anyKeyDown;
		}
	}
}