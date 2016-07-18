using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[Tooltip("Transforms position from local space to world space.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Transform.TransformPoint.html")]
	[System.Serializable]
	public class TransformPoint : TransformAction {
		[Tooltip("Position that will be transformed.")]
		public FsmVector3 position;
		[Shared]
		[Tooltip("Store the result point.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.TransformPoint (position.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = transform.TransformPoint (position.Value);
		}
	}
}