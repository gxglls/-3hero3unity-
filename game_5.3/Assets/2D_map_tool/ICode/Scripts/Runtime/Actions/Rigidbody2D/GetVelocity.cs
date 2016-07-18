using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Gets the velocity of a Rigidbody2D.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html")]
	[System.Serializable]
	public class GetVelocity : Rigidbody2DAction {
		[Shared][Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value=rigidbody.velocity;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			store.Value=rigidbody.velocity;
		}
		
	}
}