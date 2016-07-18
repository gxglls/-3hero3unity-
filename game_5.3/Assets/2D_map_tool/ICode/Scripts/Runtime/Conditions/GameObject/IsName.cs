using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.GameObject)]
	[Tooltip("Does the name of the game object equals a string value.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject-layer.html")]
	[System.Serializable]
	public class IsName : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The string to test with.")]
		public FsmString value;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return (gameObject.Value.name == value.Value)== equals.Value;
		}
	}
}