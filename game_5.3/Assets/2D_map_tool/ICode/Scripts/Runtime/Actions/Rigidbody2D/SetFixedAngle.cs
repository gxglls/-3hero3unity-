using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Should the rigidbody be prevented from rotating?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-fixedAngle.html")]
	[System.Serializable]
	public class SetFixedAngle : Rigidbody2DAction {
		[Tooltip("Value to set")]
		public FsmBool value;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.fixedAngle = value.Value;
			Finish ();
		}
	}
}