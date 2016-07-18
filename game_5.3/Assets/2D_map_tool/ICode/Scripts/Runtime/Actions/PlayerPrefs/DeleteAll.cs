using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Removes all keys and values from the preferences. Use with caution.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.DeleteAll.html")]
	[System.Serializable]
	public class DeleteAll : StateAction {

		public override void OnEnter ()
		{	
			PlayerPrefs.DeleteAll ();
			Finish ();
		}
		
	}
}