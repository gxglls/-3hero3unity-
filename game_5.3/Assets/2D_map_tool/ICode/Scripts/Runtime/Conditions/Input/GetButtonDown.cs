using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user pressed down the virtual button identified by buttonName.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input.GetButtonDown.html")]
	[System.Serializable]
	public class GetButtonDown : Condition {
		[DefaultValue("Fire1")]
		public FsmString buttonName;
		
		public override bool Validate ()
		{
			return Input.GetButtonDown(buttonName.Value);
		}
	}
}