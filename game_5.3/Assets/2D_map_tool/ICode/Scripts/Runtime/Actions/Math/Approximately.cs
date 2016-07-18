using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]    
	[Tooltip("Compares two floating point values if they are similar.")]  
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Approximately.html")]
	[System.Serializable]
	public class Approximately : StateAction {
		[Tooltip("First value to use.")]
		public FsmFloat a;
		[Tooltip("Second value to use.")]
		public FsmFloat b;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Approximately (a.Value, b.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Approximately (a.Value, b.Value);
		}
	}
}