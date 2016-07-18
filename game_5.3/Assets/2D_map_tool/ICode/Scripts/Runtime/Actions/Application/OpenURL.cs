using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("Opens the url in a browser.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application.OpenURL.html")]
	[System.Serializable]
	public class OpenURL : StateAction {
		[Tooltip("Url to open.")]
		public FsmString url;
		
		public override void OnEnter ()
		{
			Application.OpenURL (url.Value);
			Finish ();
		}
	}
}