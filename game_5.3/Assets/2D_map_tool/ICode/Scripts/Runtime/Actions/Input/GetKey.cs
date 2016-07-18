using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns true while the user holds down the key identified by name.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetKey.html")]
	[System.Serializable]
	public class GetKey : StateAction {
		[Tooltip("Key name.")]
		public FsmString keyName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetKey (keyName.Value);	
		}
	}
}