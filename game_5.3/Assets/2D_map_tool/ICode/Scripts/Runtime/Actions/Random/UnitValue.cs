using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Random)]
	[Tooltip("Returns a random number between 0.0 [inclusive] and 1.0 [inclusive]")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Random-value.html")]
	[System.Serializable]
	public class UnitValue : StateAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Random.value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Random.value;
		}
	}
}