using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPhysics{
	[Category(Category.Physics)]
	[Tooltip("Get information when the ray intersects any collider.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Physics.Raycast.html")]
	[System.Serializable]
	public class Raycast : StateAction {
		[NotRequired]
		[SharedPersistent]
		[InspectorLabel("Game Object")]
		[Tooltip("Use a target instead of origin position.")]
		public FsmGameObject target;
		[NotRequired]
		[Tooltip("The starting point of the ray in world coordinates.")]
		public FsmVector3 origin;
		[Tooltip("The direction of the ray.")]
		public Direction direction;
		public Space space;

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
		[NotRequired]
		[Tooltip("Send a hit event.")]
		public FsmString hitEvent;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoRaycast ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			DoRaycast ();
		}

		private void DoRaycast(){
			RaycastHit hit;
			Vector3 position = FsmUtility.GetPosition (target, origin);
			Vector3 dir = GetDirection ();
			if (Physics.Raycast (position, dir,out hit, distance.Value, layerMask)) {
				if(!hitDistance.IsNone)
					hitDistance.Value=hit.distance;
				if(!hitNormal.IsNone)
					hitNormal.Value=hit.normal;
				if(!hitPoint.IsNone)
					hitPoint.Value=hit.point;
				if(!hitGameObject.IsNone)
					hitGameObject.Value=hit.transform.gameObject;
				if(!hitEvent.IsNone)
					this.Root.Owner.SendEvent(hitEvent.Value,null);
			}
		}

		private Vector3 GetDirection()
		{
			Vector3 dir = space==Space.Self?target.Value.transform.forward:Vector3.forward; 
			
			switch(direction){
			case Direction.Backward:
				dir = space== Space.Self?- target.Value.transform.forward:-Vector3.forward;
				break;
			case Direction.Up:
				dir = space==Space.Self?target.Value.transform.up:Vector3.up;
				break;
			case Direction.Down:
				dir = space==Space.Self?-target.Value.transform.up:-Vector3.up;
				break;
			case Direction.Left:
				dir = space==Space.Self? -target.Value.transform.right:-Vector3.right;
				break;
			case Direction.Right:
				dir = space==Space.Self?target.Value.transform.right:Vector3.right;
				break;
			}
			
			return dir;
		}

		public enum Direction
		{
			Forward,
			Backward,
			Up,
			Down,
			Left,
			Right
		}
		
	}
}