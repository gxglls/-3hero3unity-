using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Applies a force to the rigidbody that simulates explosion effects. The explosion force will fall off linearly with distance to the rigidbody.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Rigidbody.AddExplosionForce.html")]
	[System.Serializable]
	public class AddExplosionForce : RigidbodyAction {
		[Tooltip("The force to add.")]
		public FsmFloat explosionForce;
		[Tooltip("Position to add the force at.")]
		public FsmVector3 position;
		[Tooltip("Radius to add the force inside.")]
		public FsmFloat radius;
		[Tooltip("Upwards modifier.")]
		public FsmFloat upwardsModifier;
		[Tooltip("Option for how to apply a force using Rigidbody.AddForce.")]
		public ForceMode mode;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.AddExplosionForce (explosionForce.Value, position.Value, radius.Value, upwardsModifier.Value, mode);
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnFixedUpdate ()
		{
			rigidbody.AddExplosionForce (explosionForce.Value, position.Value, radius.Value, upwardsModifier.Value, mode);
		}
		
	}
}