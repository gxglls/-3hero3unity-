using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Adds a torque to the rigidbody relative to the rigidbodie's own coordinate system.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddRelativeTorque.html")]
	[System.Serializable]
	public class AddRelativeTorque : RigidbodyAction {
		[Tooltip("The torque to add.")]
		public FsmVector3 torque;
		[Tooltip("Option for how to apply a force using Rigidbody.AddForce.")]
		public ForceMode mode;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddRelativeTorque (torque.Value, mode);
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			rigidbody.AddRelativeTorque (torque.Value, mode);
		}
		
	}
}