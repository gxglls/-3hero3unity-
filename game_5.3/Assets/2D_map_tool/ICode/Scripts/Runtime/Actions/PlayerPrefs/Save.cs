using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[Category(Category.PlayerPrefs)]
	[Tooltip("Writes all modified preferences to disk.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/PlayerPrefs.Save.html")]
	[System.Serializable]
	public class Save : StateAction {
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			PlayerPrefs.Save ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			PlayerPrefs.Save ();
		}
		
	}
}