using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[Category(Category.GameObject)]
	[Tooltip("Returns true if the GameObject has a specified component.")]    
	[System.Serializable]
	public class HasComponent : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to test.")]
		public FsmGameObject gameObject;
		[Component]
		[Tooltip("Component to check.")]
		public FsmString component;
		[Tooltip("Does the result equals this condition.")]
		public FsmBool equals;

		
		public override bool Validate ()
		{
			return gameObject.Value.GetComponent(component.Value)== equals.Value;
		}
	}
}