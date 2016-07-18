using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("The method used by the physics engine to check if two objects have collided.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-collisionDetectionMode.html")]
	[System.Serializable]
	public class SetCollisionDetectionMode : Rigidbody2DAction {
		[Tooltip("Mode to set")]
		public CollisionDetectionMode2D mode;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.collisionDetectionMode = mode;
			Finish ();
		}
	}
}