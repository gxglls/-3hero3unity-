using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityVector3{
	[Category(Category.Vector3)]   
	[Tooltip("")]
	[HelpUrl("")]
	[System.Serializable]
	public class SignAngle : StateAction {
		public FsmVector3 from;
		public FsmVector3 to;
		public FsmVector3 up;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			DoSignAngle ();
			if (!everyFrame) {
				Finish();		
			}
		}

		public override void OnUpdate ()
		{
			DoSignAngle ();
		}

		private void DoSignAngle(){
			if (to.Value == Vector3.zero) {
				store.Value=0.0f;
				return;
			}
			// Create a float to store the angle between the facing of the enemy and the direction it's travelling.
			float angle = Vector3.Angle(from.Value, to.Value);
			// Find the cross product of the two vectors (this will point up if the velocity is to the right of forward).
			Vector3 normal = Vector3.Cross(from.Value, to.Value);
			// The dot product of the normal with the upVector will be positive if they point in the same direction.
			angle *= Mathf.Sign(Vector3.Dot(normal, up.Value));
			// We need to convert the angle we've found from degrees to radians.
			angle *= Mathf.Deg2Rad;
			store.Value= angle;
		}
	}
}