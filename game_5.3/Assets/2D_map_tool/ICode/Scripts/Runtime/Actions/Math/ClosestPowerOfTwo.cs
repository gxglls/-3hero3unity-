using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns the closest power of two value.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.ClosestPowerOfTwo.html")]
	[System.Serializable]
	public class ClosestPowerOfTwo : StateAction {
		[Tooltip("The value to use.")]
		public FsmInt value;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.ClosestPowerOfTwo (value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.ClosestPowerOfTwo (value.Value);
		}
	}
}