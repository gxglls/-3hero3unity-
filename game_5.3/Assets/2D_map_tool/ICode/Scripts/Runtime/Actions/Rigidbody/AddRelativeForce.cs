using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Adds a force to the rigidbody relative to its coordinate system.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddRelativeForce.html")]
	[System.Serializable]
	public class AddRelativeForce : RigidbodyAction {
		[Tooltip("The force to add.")]
		public FsmVector3 force;
		[Tooltip("Option for how to apply a force using Rigidbody.AddForce.")]
		public ForceMode mode;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddRelativeForce (force.Value, mode);
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddRelativeForce (force.Value, mode);
		}
		
	}
}