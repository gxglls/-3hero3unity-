using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Activates/Deactivates the GameObject.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject.SetActive.html")]
	[System.Serializable]
	public class SetActive : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The value to use.")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			gameObject.Value.SetActive(value.Value);
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			gameObject.Value.SetActive(value.Value);
		}
	}
}