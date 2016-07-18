using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user pressed the given mouse button.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input.GetMouseButtonDown.html")]
	[System.Serializable]
	public class GetMouseButtonDown : Condition {
		[Tooltip("Button values are 0 for left button, 1 for right button, 2 for the middle button.")]
		public FsmInt button;
		
		public override bool Validate ()
		{
			return Input.GetMouseButtonDown(button.Value);
		}
	}
}