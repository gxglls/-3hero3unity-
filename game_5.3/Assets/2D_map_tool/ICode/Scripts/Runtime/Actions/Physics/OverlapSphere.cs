using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityPhysics{
	[Category(Category.Physics)]
	[Tooltip("Returns an array with all colliders touching or inside the sphere.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html")]
	[System.Serializable]
	public class OverlapSphere : StateAction {
		[Tooltip("The starting point.")]
		public FsmVector3 origin;
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Set the position of a GameObject as origin.")]
		public FsmGameObject target;
		public FsmFloat radius;
		[Tooltip("Layer masks can be used selectively filter game objects for example when casting rays.")]
		public LayerMask layerMask;
		[NotRequired]
		[Shared]
		public FsmArray hitGameObjects;
		[NotRequired]
		[Shared]
		public FsmGameObject randomGameObject;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoOverlapSphere ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{	
			DoOverlapSphere ();
		}

		private void DoOverlapSphere(){
			Collider[] hits = Physics.OverlapSphere (FsmUtility.GetPosition(target,origin),radius.Value, layerMask);
			if (!hitGameObjects.IsNone) {
				List<object> gos = new List<object> ();
				foreach (Collider hit in hits) {
					gos.Add (hit.gameObject);
				}
				hitGameObjects.Value = gos.ToArray ();
			}
			if (!randomGameObject.IsNone) {
				Collider randomCollider=hits.GetRandom<Collider>();
				if(randomCollider != null)
					randomGameObject.Value=randomCollider.gameObject;
			}
		}
	}
}