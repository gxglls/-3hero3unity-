using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Coefficient of drag.Drag is the tendency of an object to slow down due to friction with the air or water that surrounds it. The linear drag applies to positional movement and is set up separately from the angular drag that affects rotational movement. A higher value of drag will cause an object's rotation to come to rest more quickly following a collision or force.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-drag.html")]
	[System.Serializable]
	public class SetDrag : Rigidbody2DAction {
		[Tooltip("Drag to set")]
		public FsmFloat drag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.drag = drag.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.angularDrag = drag.Value;
		}
		
	}
}