using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Sets the mass of the rigidbody.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-mass.html")]
	[System.Serializable]
	public class SetMass : Rigidbody2DAction {
		[Tooltip("Value to set")]
		public FsmFloat mass;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.mass = mass.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.mass = mass.Value;
		}
	}
}