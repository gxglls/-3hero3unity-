using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Returns the largest integer smaller to or equal to f.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Floor.html")]
	[System.Serializable]
	public class Floor : StateAction {
		[Tooltip("The value to use.")]
		public FsmFloat f;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.Floor (f.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.Floor (f.Value);
		}
	}
}