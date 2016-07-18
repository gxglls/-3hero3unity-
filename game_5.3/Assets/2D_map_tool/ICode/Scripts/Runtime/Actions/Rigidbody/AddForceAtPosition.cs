using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Applies force at position. As a result this will apply a torque and force on the object.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddForceAtPosition.html")]
	[System.Serializable]
	public class AddForceAtPosition : RigidbodyAction {
		[Tooltip("The force to add.")]
		public FsmVector3 force;
		[Tooltip("Position to add the force at.")]
		public FsmVector3 position;
		[Tooltip("Option for how to apply a force using Rigidbody.AddForce.")]
		public ForceMode mode;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddForceAtPosition (force.Value, position.Value, mode);
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddForceAtPosition (force.Value, position.Value, mode);
		}
		
	}
}