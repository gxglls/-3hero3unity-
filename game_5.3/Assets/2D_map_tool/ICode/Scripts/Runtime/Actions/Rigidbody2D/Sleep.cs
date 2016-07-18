using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Make the rigidbody sleep.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody2D.Sleep.html")]
	[System.Serializable]
	public class Sleep : Rigidbody2DAction {
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.Sleep();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnFixedUpdate ()
		{
			rigidbody.Sleep();
		}
		
	}
}