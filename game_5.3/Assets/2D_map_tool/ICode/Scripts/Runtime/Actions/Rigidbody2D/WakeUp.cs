using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Disables the sleeping state of a rigidbody.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody2D.WakeUp.html")]
	[System.Serializable]
	public class WakeUp : Rigidbody2DAction {
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.WakeUp();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.WakeUp();
		}
		
	}
}