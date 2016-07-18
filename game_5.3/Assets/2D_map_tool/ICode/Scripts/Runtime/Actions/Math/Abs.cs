using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]
	[Tooltip("Returns the absolute value of f.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Abs.html")]
	[System.Serializable]
	public class Abs : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Abs (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Abs (f.Value);
		}
	}
}