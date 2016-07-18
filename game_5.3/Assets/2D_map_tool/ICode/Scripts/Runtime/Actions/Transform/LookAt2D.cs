using UnityEngine;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]    
	[Tooltip("Same as LookAt, just for 2D.")]
	[System.Serializable]
	public class LookAt2D : TransformAction {
		[SharedPersistent]
		[Tooltip("GameObject to look at.")]
		public FsmGameObject target;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		protected Transform mTarget;

		public override void OnEnter ()
		{
			base.OnEnter ();
			mTarget = ((GameObject)target.Value).transform;
			DoLookAt2D ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoLookAt2D ();
		}

		private void DoLookAt2D(){
			Vector3 position =mTarget.position;
			Vector3 dir = position - transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
	}
}