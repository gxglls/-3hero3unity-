using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns the largest integer smaller to or equal to f.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.FloorToInt.html")]
	[System.Serializable]
	public class FloorToInt : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.FloorToInt (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.FloorToInt (f.Value);
		}
	}
}