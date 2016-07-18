using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[Tooltip("The position of the transform in world space.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Transform-position.html")]
	[System.Serializable]
	public class GetPosition : TransformAction {
		[Shared]
		[NotRequired]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Shared]
		[NotRequired]
		[Tooltip("Store the x componet.")]
		public FsmFloat x;
		[Shared]
		[NotRequired]
		[Tooltip("Store the y componet.")]
		public FsmFloat y;
		[Shared]
		[NotRequired]
		[Tooltip("Store the z componet.")]
		public FsmFloat z;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetPosition ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetPosition ();
		}

		private void DoGetPosition(){
			store.Value = transform.position;
			if(!x.IsNone)
				x.Value = store.Value.x;
			if(!y.IsNone)
				y.Value = store.Value.y;
			if(!z.IsNone)
				z.Value = store.Value.z;

		}
	}
}