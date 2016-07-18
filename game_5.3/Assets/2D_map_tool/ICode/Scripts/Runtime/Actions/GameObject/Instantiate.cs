using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Clones the object original.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Object.Instantiate.html")]
	[System.Serializable]
	public class Instantiate : StateAction {
		[Tooltip("An existing object that you want to make a copy of.")]
		public FsmGameObject original;
		[NotRequired]
		[SharedPersistent]
		[Tooltip("Optional instantiates at targets position.")]
		public FsmGameObject target;
		[NotRequired]
		[Tooltip("Position for the new object.")]
		public FsmVector3 position;
		[NotRequired]
		[Tooltip("Orientation of the new object.")]
		public FsmVector3 rotation;
		[NotRequired]
		[Shared]
		[Tooltip( "Instantiated clone of the original.")]
		public FsmGameObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoInstantiate ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoInstantiate ();
		}

		private void DoInstantiate(){
			store.Value = (GameObject)Instantiate (original.Value, FsmUtility.GetPosition(target, position), target.Value != null && rotation.IsNone?target.Value.transform.rotation:Quaternion.Euler(rotation.Value));
		}
	}
}