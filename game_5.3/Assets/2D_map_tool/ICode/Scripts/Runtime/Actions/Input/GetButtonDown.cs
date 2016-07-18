using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user pressed down the virtual button identified by buttonName.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetButtonDown.html")]
	[System.Serializable]
	public class GetButtonDown : StateAction {
		[Tooltip("Virtual button name.")]
		public FsmString buttonName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetButtonDown (buttonName.Value);	
		}
	}
}