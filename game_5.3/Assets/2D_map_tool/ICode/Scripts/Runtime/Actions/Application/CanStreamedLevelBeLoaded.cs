using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("Can the streamed level be loaded?")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application.CanStreamedLevelBeLoaded.html")]
	[System.Serializable]
	public class CanStreamedLevelBeLoaded : StateAction {
		[Tooltip("The name of the level.")]
		public FsmString level;
		[Shared]
		[Tooltip("Result to store.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Application.CanStreamedLevelBeLoaded (level.Value);	
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Application.CanStreamedLevelBeLoaded (level.Value);	
		}
	}
}