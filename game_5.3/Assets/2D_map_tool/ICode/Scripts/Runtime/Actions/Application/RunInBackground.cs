using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("Should the player be running when the application is in the background?")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application-runInBackground.html")]
	[System.Serializable]
	public class RunInBackground : StateAction {
		[Tooltip("State value to set, true or false.")]
		public FsmBool state;
		
		public override void OnEnter ()
		{
			Application.runInBackground = state.Value;
			Finish ();
		}
	}
}