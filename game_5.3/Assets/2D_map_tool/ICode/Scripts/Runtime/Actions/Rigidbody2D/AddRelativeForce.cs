using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Adds a force to the rigidbody. As a result the rigidbody will start moving.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody2D.AddRelativeForce.html")]
	[System.Serializable]
	public class AddRelativeForce : Rigidbody2DAction {
		[Tooltip("The force to add.")]
		public FsmVector2 force;
		public ForceMode2D mode;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddRelativeForce (force.Value,mode);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddRelativeForce (force.Value,mode);
		}
		
	}
}