using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Returns true if key exists in the preferences.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.HasKey.html")]
	[System.Serializable]
	public class HasKey : PlayerPrefsAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = PlayerPrefs.HasKey (key.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = PlayerPrefs.HasKey (key.Value);
		}
		
	}
}