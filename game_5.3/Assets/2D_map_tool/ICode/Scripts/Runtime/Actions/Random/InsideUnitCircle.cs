using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Random)]
	[Tooltip("Random point inside a circle with radius.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Random-insideUnitCircle.html")]
	[System.Serializable]
	public class InsideUnitCircle : StateAction {
		[Tooltip("Radius of the circle.")]
		public FsmFloat radius;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Random.insideUnitCircle * radius.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Random.insideUnitCircle * radius.Value;
		}
	}
}