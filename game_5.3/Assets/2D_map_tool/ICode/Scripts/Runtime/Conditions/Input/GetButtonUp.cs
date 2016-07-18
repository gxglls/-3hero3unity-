using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Input)]
	[Tooltip("Returns true the first frame the user releases the virtual button identified by buttonName.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Input.GetButtonUp.html")]
	[System.Serializable]
	public class GetButtonUp : Condition {
		[DefaultValue("Fire1")]
		public FsmString buttonName;
		
		public override bool Validate ()
		{
			return Input.GetButtonUp(buttonName.Value);
		}
	}
}