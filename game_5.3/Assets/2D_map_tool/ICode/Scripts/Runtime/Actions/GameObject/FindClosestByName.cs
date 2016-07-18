using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Finds the closest game object to the target.")]
	[HelpUrl("")]
	[System.Serializable]
	public class FindClosestByName : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[InspectorLabel("Name")]
		[Tooltip("The name of the game object.")]
		public FsmString _name;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmGameObject store;

		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			store.Value = gameObject.Value.FindClosestByName(_name.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = gameObject.Value.FindClosestByName(_name.Value);
		}
	
	}
}