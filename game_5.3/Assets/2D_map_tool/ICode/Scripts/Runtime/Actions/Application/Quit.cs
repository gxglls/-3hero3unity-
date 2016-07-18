using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("Quits the player application. Quit is ignored in the editor or the web player.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Application.Quit.html")]
	[System.Serializable]
	public class Quit : StateAction {

		public override void OnEnter ()
		{
			Application.Quit ();
			Finish ();
		}
	}
}