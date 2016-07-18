using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace ICode.Conditions.UnityGUI{
	[Category(Category.GUI)]    
	[System.Serializable]
	public class IsPointerOverGameObject : Condition {
		[Tooltip("Does the result equals this value?")]
		public FsmBool equals;


		public override bool Validate ()
		{
			return (EventSystem.current.IsPointerOverGameObject () == equals.Value);
		}
	}
}