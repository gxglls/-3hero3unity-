using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Coefficient of angular drag.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-angularDrag.html")]
	[System.Serializable]
	public class SetAngularDrag : Rigidbody2DAction {
		[Tooltip("Drag to set")]
		public FsmFloat angularDrag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.angularDrag = angularDrag.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.angularDrag = angularDrag.Value;
		}
		
	}
}