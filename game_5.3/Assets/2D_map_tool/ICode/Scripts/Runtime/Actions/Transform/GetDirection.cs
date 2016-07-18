using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]  
	[Tooltip("Get the direction of the gameObject and target.")]
	[HelpUrl("")]
	[System.Serializable]
	public class GetDirection : TransformAction {
		[SharedPersistent]
		public FsmGameObject target;
		[Shared]
		[NotRequired]
		[Tooltip("The normalized direction")]
		public FsmVector3 normalized;
		[Shared]
		[NotRequired]
		[Tooltip("The magnitude of the direction")]
		public FsmFloat magnitude;
		[Shared]
		[NotRequired]
		[Tooltip("The direction")]
		public FsmVector3 direction;
		[Shared]
		[NotRequired]
		[Tooltip("X component of the direction.")]
		public FsmFloat x;
		[Shared]
		[NotRequired]
		[Tooltip("Y component of the direction.")]
		public FsmFloat y;
		[Shared]
		[NotRequired]
		[Tooltip("Z component of the direction.")]
		public FsmFloat z;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		protected Transform mTarget;

		public override void OnEnter ()
		{
			base.OnEnter ();
			mTarget = target.Value.transform;
			DoGetDirection ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetDirection ();
		}

		private void DoGetDirection(){
			Vector3 dir = mTarget.position - transform.position;
			if(!normalized.IsNone)
				normalized.Value = dir.normalized;
			if(!magnitude.IsNone)
				magnitude.Value = dir.magnitude;
			if(!direction.IsNone)
				direction.Value = dir;
			if(!x.IsNone)
				x.Value = dir.x;
			if(!y.IsNone)
				y.Value = dir.y;
			if(!z.IsNone)
				z.Value = dir.z;
		}
	}
}