using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Angular drag can be used to slow down the rotation of an object. The higher the drag the more the rotation slows down.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody-angularDrag.html")]
	[System.Serializable]
	public class SetAngularDrag : RigidbodyAction {
		[Tooltip("Angular drag to set.")]
		public FsmFloat angularDrag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.angularDrag = angularDrag.Value;
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.angularDrag = angularDrag.Value;
		}
		
	}
}