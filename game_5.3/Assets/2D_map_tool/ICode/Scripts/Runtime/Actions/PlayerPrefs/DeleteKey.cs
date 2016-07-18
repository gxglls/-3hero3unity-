using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Removes key and its corresponding value from the preferences.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.DeleteKey.html")]
	[System.Serializable]
	public class DeleteKey : PlayerPrefsAction {

		public override void OnEnter ()
		{	
			PlayerPrefs.DeleteKey (key.Value);
			Finish ();
		}
		
	}
}