using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody2D{
	[Category("Rigidbody2D")]    
	[Tooltip("Gets the mass of a Rigidbody2D.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody2D-mass.html")]
	[System.Serializable]
	public class GetMass : Rigidbody2DAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value=rigidbody.mass;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value=rigidbody.mass;
		}
		
	}
}