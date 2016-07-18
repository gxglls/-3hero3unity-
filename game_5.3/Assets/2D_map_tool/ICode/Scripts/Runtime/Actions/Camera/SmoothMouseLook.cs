using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("MouseLook rotates the transform based on the mouse delta.")]
	[System.Serializable]
	public  class SmoothMouseLook : CameraAction {
		
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
		
		private List<float> rotArrayX;
		float rotAverageX = 0F;	
		
		private List<float> rotArrayY;
		float rotAverageY = 0F;
		
		public float frameCounter = 20;
		
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
			rotArrayX = new List<float> ();
			rotArrayY = new List<float> ();
		}
		
		public override void OnUpdate ()
		{
			if (axes == RotationAxes.MouseXAndY)
			{			
				rotAverageY = 0f;
				rotAverageX = 0f;
				
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				
				rotArrayY.Add(rotationY);
				rotArrayX.Add(rotationX);
				
				if (rotArrayY.Count >= frameCounter) {
					rotArrayY.RemoveAt(0);
				}
				if (rotArrayX.Count >= frameCounter) {
					rotArrayX.RemoveAt(0);
				}
				
				for(int j = 0; j < rotArrayY.Count; j++) {
					rotAverageY += rotArrayY[j];
				}
				for(int i = 0; i < rotArrayX.Count; i++) {
					rotAverageX += rotArrayX[i];
				}
				
				rotAverageY /= rotArrayY.Count;
				rotAverageX /= rotArrayX.Count;
				
				rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
				rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
				
				Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
				Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
				
				transform.localRotation = originalRotation * xQuaternion * yQuaternion;
			}
			else if (axes == RotationAxes.MouseX)
			{			
				rotAverageX = 0f;
				
				rotationX += Input.GetAxis("Mouse X") * sensitivityX;
				
				rotArrayX.Add(rotationX);
				
				if (rotArrayX.Count >= frameCounter) {
					rotArrayX.RemoveAt(0);
				}
				for(int i = 0; i < rotArrayX.Count; i++) {
					rotAverageX += rotArrayX[i];
				}
				rotAverageX /= rotArrayX.Count;
				
				rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
				
				Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
				transform.localRotation = originalRotation * xQuaternion;			
			}
			else
			{			
				rotAverageY = 0f;
				
				rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
				
				rotArrayY.Add(rotationY);
				
				if (rotArrayY.Count >= frameCounter) {
					rotArrayY.RemoveAt(0);
				}
				for(int j = 0; j < rotArrayY.Count; j++) {
					rotAverageY += rotArrayY[j];
				}
				rotAverageY /= rotArrayY.Count;
				
				rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
				
				Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
				transform.localRotation = originalRotation * yQuaternion;
			}
		}
		
		public float ClampAngle (float angle, float min, float max)
		{
			angle = angle % 360;
			if ((angle >= -360F) && (angle <= 360F)) {
				if (angle < -360F) {
					angle += 360F;
				}
				if (angle > 360F) {
					angle -= 360F;
				}			
			}
			return Mathf.Clamp (angle, min, max);
		}
	}
}