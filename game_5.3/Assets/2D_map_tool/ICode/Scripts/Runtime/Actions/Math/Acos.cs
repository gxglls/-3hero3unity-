using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]
	[Tooltip("Returns the arc-cosine of f - the angle in radians whose cosine is f.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Acos.html")]
	[System.Serializable]
	public class Acos : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Acos (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Acos (f.Value);
		}
	}
}