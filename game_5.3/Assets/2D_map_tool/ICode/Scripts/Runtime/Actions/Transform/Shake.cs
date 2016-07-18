using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[System.Serializable]
	public class Shake : TransformAction {
		public FsmFloat intensity;
		public FsmFloat decay;

		private Vector3 originPosition;
		private Quaternion originRotation;
		private float shakeDecay;
		private float shakeIntensity;
		public override void OnEnter ()
		{
			base.OnEnter ();
			originPosition = transform.position;
			originRotation = transform.rotation;
			shakeIntensity = intensity.Value;
			shakeDecay = decay.Value;
		}

		public override void OnUpdate ()
		{
			if (shakeIntensity > 0) {
				transform.position = originPosition + Random.insideUnitSphere * shakeIntensity;
				transform.rotation = new Quaternion (
					originRotation.x + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f,
					originRotation.y + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f,
					originRotation.z + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f,
					originRotation.w + Random.Range (-shakeIntensity, shakeIntensity) * 0.2f);
				shakeIntensity -= shakeDecay;
			}
		}
	}
}