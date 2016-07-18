using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Forces a rigidbody to wake up.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody.WakeUp.html")]
	[System.Serializable]
	public class WakeUp : RigidbodyAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.WakeUp ();
			Finish ();
		}	
	}
}