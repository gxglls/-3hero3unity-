using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.Camera)]    
	[Tooltip("Is the mouse over a game object with tag.")] 
	[System.Serializable]
	public class MouseOverGameObject : Condition {
		public LayerMask mask;
		public FsmFloat maxDistance;
		[Shared]
		[NotRequired]
		public FsmGameObject store;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray.origin, ray.direction,out hit,maxDistance.Value,mask)) 
			{
				store.Value=hit.collider.gameObject;
				Debug.Log(hit.distance);
				return equals.Value== true;

			}
			return equals.Value == false;
		}
		
	}
}