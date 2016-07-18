using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Use these flags to constrain motion of Rigidbodies.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RigidbodyConstraints.html")]
	[System.Serializable]
	public class SetConstraints : RigidbodyAction {
		public RigidbodyConstraints constraints;

		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.constraints = constraints;
			proxy.onFixedUpdate-=OnFixedUpdate;
			Finish ();
		}
	}
}