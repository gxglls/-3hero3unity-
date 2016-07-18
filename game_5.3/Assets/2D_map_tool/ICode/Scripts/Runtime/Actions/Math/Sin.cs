using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns the sine of angle f in radians.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Sin.html")]
	[System.Serializable]
	public class Sin : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Sin (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Sin (f.Value);
		}
	}
}
