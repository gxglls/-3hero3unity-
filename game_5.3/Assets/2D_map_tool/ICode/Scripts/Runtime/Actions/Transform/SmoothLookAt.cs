using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[Tooltip("Rotates the transform smooth towards the target.")]
	[HelpUrl("")]
	[System.Serializable]
	public class SmoothLookAt : TransformAction {
		[NotRequired]
		[Tooltip("Position to look at.")]
		public FsmVector3 position;
		[SharedPersistent]
		[NotRequired]
		[Tooltip("GameObject to look at.")]
		public FsmGameObject target;
		[Tooltip("The angular speed in degrees/second to rotate the game object.")]
		public FsmFloat speed;
		[Tooltip("If set to true, the game object will be rotated only in y axis.")]
		public FsmBool inY;


		private Quaternion lastRotation;
		private Quaternion desiredRotation;

		public override void OnEnter ()
		{
			base.OnEnter ();
			lastRotation =((GameObject)gameObject.Value).transform.rotation;
			desiredRotation = lastRotation;
		}
		
		public override void OnUpdate ()
		{
			Vector3 targetPosition = FsmUtility.GetPosition (target,position);

			Vector3 gameObjectPosition = transform.position;

			targetPosition.y = (inY.Value ? gameObjectPosition.y : targetPosition.y);

			Vector3 diff = targetPosition - gameObjectPosition;
			if (diff != Vector3.zero && diff.sqrMagnitude > 0)
			{
				desiredRotation = Quaternion.LookRotation(diff);
			}
			
			lastRotation = Quaternion.Slerp(lastRotation, desiredRotation, speed.Value * Time.deltaTime);
			transform.rotation = lastRotation;
		}
	}
}