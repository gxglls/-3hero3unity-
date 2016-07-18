using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)] 
	[Tooltip("Subtracts one vector from another.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector3-operator_subtract.html")]
	[System.Serializable]
	public class Subtract : StateAction {
		[Tooltip("Vector3 value.")]
		public FsmVector3 a;
		[Tooltip("Vector3 value to subtract.")]
		public FsmVector3 b;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = a.Value-b.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = a.Value-b.Value;
		}
	}
}