using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.GameObject)]
	[Tooltip("Is the value of the GameObject variable null?")]
	[System.Serializable]
	public class IsNull : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;
		
		public override bool Validate ()
		{
			return (gameObject.Value == null)== equals.Value;
		}
	}
}