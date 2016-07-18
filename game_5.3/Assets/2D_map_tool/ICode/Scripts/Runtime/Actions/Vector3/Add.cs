using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Vector3)] 
	[Tooltip("Adds two vectors.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Vector3-operator_add.html")]
	[System.Serializable]
	public class Add : StateAction {
		[Tooltip("Vector3 value.")]
		public FsmVector3 a;
		[Tooltip("Vector3 value to add.")]
		public FsmVector3 b;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = a.Value+b.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = a.Value+b.Value;
		}
	}
}