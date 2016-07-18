using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Resets all input. After ResetInputAxes all axes return to 0 and all buttons return to 0 for one frame.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.ResetInputAxes.html")]
	[System.Serializable]
	public class ResetInputAxes : StateAction {
		
		public override void OnEnter ()
		{
			Input.ResetInputAxes ();	
			Finish ();
		}
	}
}