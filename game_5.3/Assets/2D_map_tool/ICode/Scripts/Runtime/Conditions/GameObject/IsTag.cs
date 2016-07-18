using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.GameObject)]
	[Tooltip("Checks if the game object's tag is equal to the test tag.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject-tag.html")]
	[System.Serializable]
	public class IsTag : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tag]
		[Tooltip("The tag to test with.")]
		public FsmString tag;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return (gameObject.Value.tag == tag.Value)== equals.Value;
		}
	}
}