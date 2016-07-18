using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns the smallest integer greater to or equal to f.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Ceil.html")]
	[System.Serializable]
	public class Ceil : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Ceil (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Ceil (f.Value);
		}
	}
}