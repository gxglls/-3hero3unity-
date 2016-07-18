using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("MouseLook rotates the transform based on the mouse delta.")]
	[System.Serializable]
	public  class MouseLook : CameraAction {
	
		public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
		public RotationAxes axes = RotationAxes.MouseXAndY;
		[DefaultValue(15f)]
		public FsmFloat sensitivityX;
		[DefaultValue(15f)]
		public FsmFloat sensitivityY;

		[DefaultValue(-360f)]
		public FsmFloat minimumX;
		[DefaultValue(360f)]
		public FsmFloat maximumX;
		[DefaultValue(-60f)]
		public FsmFloat minimumY;
		[DefaultValue(60f)]
		public FsmFloat maximumY;
		
		float rotationX = 0F;
		float rotationY = 0F;
		
		Quaternion originalRotation;
		Transform transform;
		public override void OnEnter (){
			base.OnEnter ();
			Rigidbody rigidbody = gameObject.Value.GetComponent<Rigidbody> ();
			if (rigidbody) {
				rigidbody.freezeRotation = true;
			}
			transform = gameObject.Value.GetComponent<Transform> ();
			originalRotation = transform.localRotation;
		}

		public override void OnUpdate ()
		{
			if (axes == RotationAxes.MouseXAndY)
			{
				// Read the mouse input axis
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				
				rotationX = ClampAngle (rotationX, minimumX, maximumX);
				rotationY = ClampAngle (rotationY, minimumY, maximumY);
				
				Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
				Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
				
				transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			}
			else if (axes == RotationAxes.MouseX)
			{
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				rotationX = ClampAngle (rotationX, minimumX, maximumX);
				
				Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
				transform.localRotation = originalRotation * xQuaternion;
			}
			else
			{
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationY = ClampAngle (rotationY, minimumY, maximumY);
				
				Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.left);
				transform.localRotation = originalRotation * yQuaternion;
			}
		}

		public float ClampAngle (float angle, float min, float max)
		{
			if (angle < -360F)
				angle += 360F;
			if (angle > 360F)
				angle -= 360F;
			return Mathf.Clamp (angle, min, max);
		}
	}
}