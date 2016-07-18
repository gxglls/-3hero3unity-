using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)]    
	[Tooltip("Returns the length of this vector.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Vector3-magnitude.html")]
	[System.Serializable]
	public class Magnitude : StateAction {
		[Tooltip("Vector3 value.")]
		public FsmVector3 vector;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = vector.Value.magnitude;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = vector.Value.magnitude;
		}
	}
}