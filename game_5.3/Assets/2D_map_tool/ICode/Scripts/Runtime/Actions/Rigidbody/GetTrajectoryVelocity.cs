using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[System.Serializable]
	public class GetTrajectoryVelocity : StateAction {
		[Tooltip("Start position.")]
		public FsmVector3 start;
		[Tooltip("End position.")]
		public FsmVector3 target;
		[Tooltip("Time to complete.")]
		public FsmFloat time;
		[Tooltip("Multiplier in targets direction")]
		public FsmFloat multiplier;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;

		public override void OnEnter ()
		{
			Vector3 dir = target.Value - start.Value;
			target.Value = target.Value + dir.normalized*multiplier.Value;
			store.Value = GetTrajectory (start.Value, target.Value, time.Value);
			Finish ();
		}

		private Vector3 GetTrajectory(Vector3 origin, Vector3 target, float timeToTarget) {
			// calculate vectors
			Vector3 toTarget = target - origin;
			Vector3 toTargetXZ = toTarget;
			toTargetXZ.y = 0;
			
			// calculate xz and y
			float y = toTarget.y;
			float xz = toTargetXZ.magnitude;
			
			// calculate starting speeds for xz and y. Physics forumulase deltaX = v0 * t + 1/2 * a * t * t
			// where a is "-gravity" but only on the y plane, and a is 0 in xz plane.
			// so xz = v0xz * t => v0xz = xz / t
			// and y = v0y * t - 1/2 * gravity * t * t => v0y * t = y + 1/2 * gravity * t * t => v0y = y / t + 1/2 * gravity * t
			float t = timeToTarget;
			float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
			float v0xz = xz / t;
			
			// create result vector for calculated starting speeds
			Vector3 result = toTargetXZ.normalized;        // get direction of xz but with magnitude 1
			result *= v0xz;                                // set magnitude of xz to v0xz (starting speed in xz plane)
			result.y = v0y;                                // set y to v0y (starting speed of y plane)
			
			return result;
		}
	}
}