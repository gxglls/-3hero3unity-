using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[Tooltip("The rotation as Euler angles in degrees.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html")]
	[System.Serializable]
	public class SetEulerAngles : TransformAction {
		[Tooltip("Euler angles to set.")]
		public FsmVector3 eulerAngles;
		[Tooltip("Smooth multiplier.")]
		public FsmFloat smooth;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSetEulerAngles ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetEulerAngles ();
		}

		private void DoSetEulerAngles(){
			if (smooth.Value == 0) {
				transform.rotation=Quaternion.Euler(eulerAngles.Value);
			} else {
				transform.rotation=Quaternion.Lerp(transform.rotation, Quaternion.Euler(eulerAngles.Value),Time.deltaTime*smooth.Value);			
			}
		}
	}
}