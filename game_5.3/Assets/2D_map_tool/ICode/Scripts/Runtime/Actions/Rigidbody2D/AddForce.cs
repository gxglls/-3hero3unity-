using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Adds a force to the rigidbody. As a result the rigidbody will start moving.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody2D.AddForce.html")]
	[System.Serializable]
	public class AddForce : Rigidbody2DAction {
		[Tooltip("The force to add.")]
		public FsmVector2 force;
		public ForceMode2D mode;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddForce (force.Value,mode);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddForce (force.Value,mode);
		}
		
	}
}