using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)] 
	[Tooltip("Multiplies a vector by a number.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector3-operator_multiply.html")]
	[System.Serializable]
	public class Multiply : StateAction {
		[Tooltip("Vector3 value.")]
		public FsmVector3 vector;
		[Tooltip("Float value to multiply with.")]
		public FsmFloat a;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = vector.Value*a.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = vector.Value*a.Value;
		}
	}
}