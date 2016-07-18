using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Clones a random object from the originals list")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Object.Instantiate.html")]
	[System.Serializable]
	public class InstantiateRandom : StateAction {
		[Tooltip("An existing object that you want to make a copy of.")]
		public List<Object> originals;
		[Tooltip("Position for the new object.")]
		public FsmVector3 position;
		[SharedPersistent]
		[NotRequired]
		[Tooltip("Optional instantiates at targets position.")]
		public FsmGameObject target;
		[Tooltip("Orientation of the new object.")]
		public FsmVector3 rotation;
		[NotRequired]
		[Shared]
		[Tooltip( "Instantiated clone of the original.")]
		public FsmObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
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
			store.Value = Instantiate (originals.GetRandom<Object>(),FsmUtility.GetPosition(target,position), Quaternion.Euler (rotation.Value));
		}
	}
}