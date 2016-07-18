using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Apply a torque at the rigidbody's centre of mass.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody2D.AddTorque.html")]
	[System.Serializable]
	public class AddTorque : Rigidbody2DAction {
		[Tooltip("The torque to add.")]
		public FsmFloat torque;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddTorque (torque.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddTorque (torque.Value);
		}
		
	}
}