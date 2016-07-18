using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Finds the closest game object to the target game object.")]
	[HelpUrl("")]
	[System.Serializable]
	public class FindClosestByTag : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tag]
		[Tooltip("The tag of the game object.")]
		public FsmString tag;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmGameObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = gameObject.Value.FindClosestByTag (tag.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = gameObject.Value.FindClosestByTag (tag.Value);
		}

	}
}