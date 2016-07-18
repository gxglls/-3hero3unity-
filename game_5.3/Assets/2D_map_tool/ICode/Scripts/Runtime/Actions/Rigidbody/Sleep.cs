using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Forces a rigidbody to sleep at least one frame.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody.Sleep.html")]
	[System.Serializable]
	public class Sleep : RigidbodyAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.Sleep ();
			proxy.onFixedUpdate-=OnFixedUpdate;
			Finish ();
		}	
	}
}