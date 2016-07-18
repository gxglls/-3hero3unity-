using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("The closest point to the bounding box of the attached colliders.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody.ClosestPointOnBounds.html")]
	[System.Serializable]
	public class GetClosestPointOnBounds : RigidbodyAction {
		public FsmVector3 position;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = rigidbody.ClosestPointOnBounds (position.Value);
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = rigidbody.ClosestPointOnBounds (position.Value);
		}
	}
}