using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Sets the velocity of a Rigidbody2D.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html")]
	[System.Serializable]
	public class SetVelocity : Rigidbody2DAction {
		[Tooltip("The force to add.")]
		public FsmVector2 velocity;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.velocity = velocity.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.velocity = velocity.Value;
		}
		
	}
}