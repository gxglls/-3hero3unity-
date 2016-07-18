using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("Is Unity activated with the Pro license?")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application.HasProLicense.html")]
	[System.Serializable]
	public class HasProLicense : StateAction {
		[Shared]
		[Tooltip("Result to store.")]
		public FsmBool store;
		
		public override void OnEnter ()
		{
			store.Value = Application.HasProLicense ();
			Finish ();
		}
		
	}
}