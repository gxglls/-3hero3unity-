using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Finds the child by name.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject.Find.html")]
	[System.Serializable]
	public class FindChild : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[InspectorLabel("Name")]
		[Tooltip("The name of the child game object to find.")]
		public FsmString _name;
		public FsmBool includeInactive;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmGameObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			store.Value = gameObject.Value.FindChild (_name.Value,includeInactive.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			store.Value = gameObject.Value.FindChild (_name.Value,includeInactive.Value);
		}
	}
}