using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("Loads the level by its name.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application.LoadLevel.html")]
	[System.Serializable]
	public class LoadLevel : StateAction {
		[Tooltip("The name of the level to load.")]
		public FsmString level;

		public override void OnEnter ()
		{
			Application.LoadLevel (level.Value);
			Finish ();
		}
	}
}