using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPhysics{
	[Category(Category.Physics)]
	[Tooltip("Makes the collision detection system ignore all collisions between first GameObject and second GameObject.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Physics.IgnoreCollision.html")]
	[System.Serializable]
	public class IgnoreCollision : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject first;
		[SharedPersistent]
		[Tooltip("Second GameObject to ignore collision with.")]
		public FsmGameObject second;

		[Tooltip("Ignore the collsion if true.")]
		public FsmBool ignore;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private Collider collider1;
		private Collider collider2;

		public override void OnEnter ()
		{
			collider1 = first.Value.GetComponent<Collider> ();
			collider2 = second.Value.GetComponent<Collider> ();
			Physics.IgnoreCollision (collider1, collider2, ignore.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			Physics.IgnoreCollision (collider1, collider2, ignore.Value);
		}
	}
}