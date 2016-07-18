using UnityEngine;
using System.Collections;

namespace ICode.Actions.Math{
	[Category(Category.Math)]  
	[Tooltip("Rounds a float to int.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Mathf.RoundToInt.html")]
	[System.Serializable]
	public class RoundToInt : StateAction {
		[Tooltip("Value to round.")]
		public FsmFloat value;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmInt store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = Mathf.RoundToInt (value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = Mathf.RoundToInt (value.Value);
		}
	}
}