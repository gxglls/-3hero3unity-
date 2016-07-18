using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Debug)]
	[Tooltip("Prints a message to the console.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Debug.Log.html")]
	[System.Serializable]
	public class Log : StateAction {
		[Tooltip("Message to print.")]
		public FsmString message;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			Debug.Log (message.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			Debug.Log (message.Value);
		}
	}
}
