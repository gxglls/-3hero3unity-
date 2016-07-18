using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("The degree to which this object is affected by gravity.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-gravityScale.html")]
	[System.Serializable]
	public class SetGravityScale : Rigidbody2DAction {
		[Tooltip("Value to set")]
		public FsmFloat gravityScale;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.gravityScale = gravityScale.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.gravityScale = gravityScale.Value;
		}
		
	}
}