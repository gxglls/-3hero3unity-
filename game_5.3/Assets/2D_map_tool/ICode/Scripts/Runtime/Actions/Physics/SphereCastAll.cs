using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityPhysics{
	[Category(Category.Physics)]
	[Tooltip("Like Physics.SphereCast, but this function will return all hits the sphere sweep intersects.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Physics.SphereCastAll.html")]
	[System.Serializable]
	public class SphereCastAll : StateAction {
		[Tooltip("The starting point of the ray in world coordinates.")]
		public FsmVector3 origin;
		public FsmFloat radius;
		[Tooltip("The direction of the ray.")]
		public FsmVector3 direction;
		[Tooltip("The length of the ray.")]
		public FsmFloat distance;
		[Tooltip("Layer masks can be used selectively filter game objects for example when casting rays.")]
		public LayerMask layerMask;

		[Shared]
		public FsmArray hitGameObjects;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoSphereCastAll ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			DoSphereCastAll ();
		}

		private void DoSphereCastAll(){
			RaycastHit[] hits = Physics.SphereCastAll (origin.Value,radius.Value, direction.Value, distance.Value, layerMask);
			List<object> gos = new List<object> ();
			foreach (RaycastHit hit in hits) {
				gos.Add(hit.transform.gameObject);
			}
			hitGameObjects.Value = gos.ToArray();	
		}
	}
}