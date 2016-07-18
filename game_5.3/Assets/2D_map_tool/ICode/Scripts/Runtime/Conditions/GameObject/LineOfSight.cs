using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.GameObject)]    
	[Tooltip("Checks LineOfSight between two game objects.")]
	[System.Serializable]
	public class LineOfSight : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[SharedPersistent]
		[Tooltip("Target to check.")]
		public FsmGameObject target;
		public FsmFloat angle;
		[Tooltip("Layer masks can be used selectively filter game objects for example when casting rays.")]
		public LayerMask layerMask;
		public FsmVector3 offset;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			float targetAngle = Vector3.Angle (target.Value.transform.position - gameObject.Value.transform.position,gameObject.Value.transform.forward);
			if (Mathf.Abs (targetAngle) < angle.Value*0.5f) {
				RaycastHit hit;
				if (Physics.Linecast (gameObject.Value.transform.position + offset.Value, target.Value.transform.position + offset.Value, out hit, layerMask)) {
					if (hit.transform == target.Value.transform) {  
						return equals.Value==true;
					}
				}
			}
			return equals.Value == false;
		}
	}
}