using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityApplication{
	[Category(Category.Application)]
	[Tooltip("How far has the download progressed?")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Application.GetStreamProgressForLevel.html")]
	[System.Serializable]
	public class GetStreamProgressForLevel : StateAction {
		[Tooltip("The name of the level.")]
		public FsmString level;
		[Shared]
		[Tooltip("Result to store.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Application.GetStreamProgressForLevel (level.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Application.GetStreamProgressForLevel (level.Value);
		}
		
	}
}