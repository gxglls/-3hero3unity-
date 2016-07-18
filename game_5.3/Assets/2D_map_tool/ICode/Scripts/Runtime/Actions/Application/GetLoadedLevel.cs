using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("The name of the level that was last loaded.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Application-loadedLevelName.html")]
	[System.Serializable]
	public class GetLoadedLevel : StateAction {
		[NotRequired]
		[InspectorLabel("Name")]
		[Shared]
		[Tooltip("Store the level name.")]
		public FsmString _name;
		[NotRequired]
		[Shared]
		[Tooltip("Store the index of the level.")]
		public FsmInt index;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			_name.Value = Application.loadedLevelName;
			index.Value = Application.loadedLevel;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			_name.Value = Application.loadedLevelName;
			index.Value = Application.loadedLevel;
		}
	}
}