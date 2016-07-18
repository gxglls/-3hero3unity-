using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Random)]
	[Tooltip("Returns a random float number between and min [inclusive] and max [inclusive].")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Random.Range.html")]
	[System.Serializable]
	public class Range : StateAction {
		[Tooltip("The minimum value")]
		public FsmFloat min;
		[Tooltip("The maximum value")]
		public FsmFloat max;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Random.Range (min.Value, max.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Random.Range (min.Value, max.Value);
		}
	}
}