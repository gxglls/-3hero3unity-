using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPhysics{
	[Category(Category.Physics)]
	[Tooltip("Returns true if there is any collider intersecting the line between start and end.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Physics.Linecast.html")]
	[System.Serializable]
	public class Linecast : StateAction {
		[Tooltip("The starting point.")]
		public FsmVector3 start;
		[Tooltip("The end point.")]
		public FsmVector3 end;
		[Tooltip("Layer masks can be used selectively filter game objects for example when casting rays.")]
		public LayerMask layerMask;
		[Shared]
		[NotRequired]
		[Tooltip("The distance from the ray's origin to the impact point.")]
		public FsmFloat hitDistance;
		[Shared]
		[NotRequired]
		[Tooltip("The normal of the surface the ray hit.")]
		public FsmVector3 hitNormal;
		[Shared]
		[NotRequired]
		[Tooltip("The impact point in world space where the ray hit the collider.")]
		public FsmVector3 hitPoint;
		[Shared]
		[NotRequired]
		[Tooltip("The GameObject of the rigidbody or collider that was hit.")]
		public FsmGameObject hitGameObject;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoLineCast ();
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{	
			DoLineCast ();
		}

		private void DoLineCast(){
			RaycastHit hit;
			if (Physics.Raycast (start.Value, end.Value,out hit, layerMask)) {
				if(!hitDistance.IsNone)
					hitDistance.Value=hit.distance;
				if(!hitNormal.IsNone)
					hitNormal.Value=hit.normal;
				if(!hitPoint.IsNone)
					hitPoint.Value=hit.point;
				if(!hitGameObject.IsNone)
					hitGameObject.Value=hit.transform.gameObject;
			}

		}
		
	}
}