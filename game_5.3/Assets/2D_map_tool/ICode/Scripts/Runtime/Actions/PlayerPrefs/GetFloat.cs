using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Returns the value corresponding to key in the preference file if it exists.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.GetFloat.html")]
	[System.Serializable]
	public class GetFloat : PlayerPrefsAction {
		[Tooltip("The default value to set, if the key does not exist.")]
		public FsmFloat defaultValue;
		[Shared]
		[Tooltip("Store the result")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = PlayerPrefs.GetFloat (key.Value, defaultValue.Value);
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			store.Value = PlayerPrefs.GetFloat (key.Value, defaultValue.Value);
		}
		
	}
}