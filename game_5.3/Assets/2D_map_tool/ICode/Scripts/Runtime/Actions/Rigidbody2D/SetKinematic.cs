using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Should this rigidbody be taken out of physics control?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-isKinematic.html")]
	[System.Serializable]
	public class SetKinematic : Rigidbody2DAction {
		[Tooltip("Value to set")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.isKinematic = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.isKinematic = value.Value;
		}
	}
}