using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Apply a force at a given position in space.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody2D.AddForceAtPosition.html")]
	[System.Serializable]
	public class AddForceAtPosition : Rigidbody2DAction {
		[Tooltip("The force to add.")]
		public FsmVector2 force;
		[Tooltip("Position to add the force at.")]
		public FsmVector2 position;
	
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddForceAtPosition (force.Value, position.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.AddForceAtPosition (force.Value, position.Value);
		}
		
	}
}