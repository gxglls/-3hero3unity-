using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Set the name of the game object.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Object-name.html")]
	[System.Serializable]
	public class SetName : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[InspectorLabel("Name")]
		[Tooltip("The new name to set.")]
		public FsmString _name;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			gameObject.Value.name = _name.Value;
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			gameObject.Value.name = _name.Value;
		}
	}
}