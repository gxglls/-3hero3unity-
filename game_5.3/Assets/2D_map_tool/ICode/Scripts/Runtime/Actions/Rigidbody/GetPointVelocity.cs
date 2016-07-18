using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRigidbody{
	[Category(Category.Rigidbody)]    
	[Tooltip("The velocity of the rigidbody at the point worldPoint in global space.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Rigidbody.GetPointVelocity.html")]
	[System.Serializable]
	public class GetPointVelocity : RigidbodyAction {
		public FsmVector3 worldPoint;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = rigidbody.GetPointVelocity (worldPoint.Value);
			if (!everyFrame) {
				proxy.onFixedUpdate-=OnFixedUpdate;
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = rigidbody.GetPointVelocity (worldPoint.Value);
		}
	}
}