using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Sets velocity vector of the rigidbody.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html")]
	[System.Serializable]
	public class SetVelocity : RigidbodyAction {
		[Tooltip("Velocity to set.")]
		public FsmVector3 velocity;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.velocity = velocity.Value;
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			rigidbody.velocity = velocity.Value;
		}
		
	}
}