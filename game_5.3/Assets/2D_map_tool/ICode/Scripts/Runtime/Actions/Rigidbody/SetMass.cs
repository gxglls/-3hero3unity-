using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Sets the mass of the rigidbody.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody-mass.html")]
	[System.Serializable]
	public class SetMass : RigidbodyAction {
		[Tooltip("Mass to set.")]
		public FsmFloat mass;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.mass = mass.Value;
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.mass = mass.Value;
		}
		
	}
}