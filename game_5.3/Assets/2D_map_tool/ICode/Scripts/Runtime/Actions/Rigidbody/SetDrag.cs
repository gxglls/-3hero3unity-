using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("Drag can be used to slow down an object. The higher the drag the more the object slows down.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody-drag.html")]
	[System.Serializable]
	public class SetDrag : RigidbodyAction {
		[Tooltip("Drag to set.")]
		public FsmFloat drag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			rigidbody.drag = drag.Value;
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			rigidbody.drag = drag.Value;
		}
		
	}
}