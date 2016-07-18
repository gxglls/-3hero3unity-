using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns the arc-tangent of f - the angle in radians whose tangent is f.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Atan.html")]
	[System.Serializable]
	public class Atan : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Atan (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Atan (f.Value);
		}
	}
}