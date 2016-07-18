using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Controls whether gravity affects this rigidbody.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody-useGravity.html")]
	[System.Serializable]
	public class UseGravity : RigidbodyAction {
		[Tooltip("Value to set.")]
		public FsmBool useGravity;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.useGravity= useGravity.Value;
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.useGravity = useGravity.Value;
		}
		
	}
}