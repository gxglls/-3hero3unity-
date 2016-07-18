using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user starts pressing down the key identified by name.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetKeyDown.html")]
	[System.Serializable]
	public class GetKeyDown : StateAction {
		[Tooltip("Key name.")]
		public FsmString keyName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetKeyDown (keyName.Value);	
		}
	}
}