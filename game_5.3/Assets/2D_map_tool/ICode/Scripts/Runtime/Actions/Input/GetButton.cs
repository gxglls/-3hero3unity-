using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns true while the virtual button identified by buttonName is held down.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetButton.html")]
	[System.Serializable]
	public class GetButton : StateAction {
		[Tooltip("Virtual button name.")]
		public FsmString buttonName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;


		public override void OnUpdate ()
		{
			store.Value = Input.GetButton (buttonName.Value);	
		}
	}
}