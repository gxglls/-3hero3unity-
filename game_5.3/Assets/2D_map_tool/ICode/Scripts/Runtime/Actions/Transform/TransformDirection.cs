using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]  
	[Tooltip("Transforms direction from local space to world space.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Transform.TransformDirection.html")]
	[System.Serializable]
	public class TransformDirection : TransformAction {
		[Tooltip("Direction that will be transformed.")]
		public FsmVector3 direction;
		[Shared]
		[Tooltip("Store the result direction")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.TransformDirection (direction.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = transform.TransformDirection (direction.Value);
		}
	}
}