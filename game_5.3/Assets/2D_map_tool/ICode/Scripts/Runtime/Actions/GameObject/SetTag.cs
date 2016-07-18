using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Sets the GameObject's tag.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject-tag.html")]
	[System.Serializable]
	public class SetTag : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tag]
		[Tooltip("The new tag to set.")]
		public FsmString tag;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			gameObject.Value.tag = tag.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			gameObject.Value.tag = tag.Value;
		}
	}
}