using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]    
	[Tooltip("The blue axis of the transform in world space.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Transform-forward.html")]
	[System.Serializable]
	public class Forward : TransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.forward;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = transform.forward;
		}
	}
}