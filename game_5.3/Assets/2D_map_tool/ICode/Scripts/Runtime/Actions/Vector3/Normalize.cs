using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)] 
	[Tooltip("Returns this vector with a magnitude of 1.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Vector3-normalized.html")]
	[System.Serializable]
	public class Normalize : StateAction {
		[Tooltip("Vector3 to normalize.")]
		public FsmVector3 vector;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = vector.Value.normalized;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = vector.Value.normalized;
		}
	}
}