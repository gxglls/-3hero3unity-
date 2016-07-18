using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.GameObject)]
	[Tooltip("Checks if the game object's layer is equal to the test layer.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject-layer.html")]
	[System.Serializable]
	public class IsLayer : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Layer]
		[Tooltip("The layer to test with.")]
		public FsmInt layer;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		public override bool Validate ()
		{
			return (gameObject.Value.layer == layer.Value)== equals.Value;
		}
	}
}