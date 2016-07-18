using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Angular velocity in degrees per second.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-angularVelocity.html")]
	[System.Serializable]
	public class SetAngularVelocity: Rigidbody2DAction {
		[Tooltip("Velocity to set")]
		public FsmFloat angularVelocity;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.angularVelocity = angularVelocity.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			rigidbody.angularVelocity = angularVelocity.Value;
		}
		
	}
}