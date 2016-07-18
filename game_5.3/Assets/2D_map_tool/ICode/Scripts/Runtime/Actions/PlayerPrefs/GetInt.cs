using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Returns the value corresponding to key in the preference file if it exists.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.GetInt.html")]
	[System.Serializable]
	public class GetInt : PlayerPrefsAction {
		[Tooltip("The default value to set, if the key does not exist.")]
		public FsmInt defaultValue;
		[Shared]
		[Tooltip("Store the result")]
		public FsmInt store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = PlayerPrefs.GetInt (key.Value, defaultValue.Value);
			
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = PlayerPrefs.GetInt (key.Value, defaultValue.Value);
		}
		
	}
}