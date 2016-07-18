using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)] 
	[Tooltip("Clamps a value between a minimum float and maximum float value.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Mathf.Clamp.html")]
	[System.Serializable]
	public class Clamp : StateAction {
		[Tooltip("The value to clamp")]
		public FsmFloat value;
		[Tooltip("Min value")]
		public FsmFloat min;
		[Tooltip("Max value")]
		public FsmFloat max;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Mathf.Clamp (value.Value, min.Value, max.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Mathf.Clamp (value.Value, min.Value, max.Value);
		}
	}
}