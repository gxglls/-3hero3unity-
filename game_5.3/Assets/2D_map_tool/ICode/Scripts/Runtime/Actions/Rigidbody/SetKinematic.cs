using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Controls whether physics affects the rigidbody.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody-isKinematic.html")]
	[System.Serializable]
	public class SetKinematic : RigidbodyAction {
		[Tooltip("Value to set.")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.isKinematic = value.Value;
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.isKinematic = value.Value;
		}
		
	}
}