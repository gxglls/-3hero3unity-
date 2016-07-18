using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Calculates the shortest difference between two given angles.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.DeltaAngle.html")]
	[System.Serializable]
	public class DeltaAngle : StateAction {
		[Tooltip("Current angle")]
		public FsmFloat current;
		[Tooltip("Target angle")]
		public FsmFloat target;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = Mathf.DeltaAngle (current.Value, target.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = Mathf.DeltaAngle (current.Value, target.Value);
		}
	}
}