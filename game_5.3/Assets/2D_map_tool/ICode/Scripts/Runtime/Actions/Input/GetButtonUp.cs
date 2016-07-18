using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns true the first frame the user releases the virtual button identified by buttonName.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetButtonUp.html")]
	[System.Serializable]
	public class GetButtonUp : StateAction {
		[Tooltip("Virtual button name.")]
		public FsmString buttonName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetButtonUp (buttonName.Value);	
		}
	}
}