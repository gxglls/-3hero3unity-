using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[System.Serializable]
	public  class Pick : StateAction {
		[Tooltip("The length of the ray.")]
		public FsmFloat distance;
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

		public override void OnEnter (){
			DoPick ();
		}

		public override void OnUpdate ()
		{
			DoPick ();
		}

		private void DoPick(){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray.origin, ray.direction,out hit, distance.Value,layerMask)) 
			{
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