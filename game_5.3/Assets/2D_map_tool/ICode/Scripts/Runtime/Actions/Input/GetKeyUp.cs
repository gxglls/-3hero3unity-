using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns true during the frame the user releases the key identified by name.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetKeyUp.html")]
	[System.Serializable]
	public class GetKeyUp : StateAction {
		[Tooltip("Key name.")]
		public FsmString keyName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetKeyUp (keyName.Value);	
		}
	}
}