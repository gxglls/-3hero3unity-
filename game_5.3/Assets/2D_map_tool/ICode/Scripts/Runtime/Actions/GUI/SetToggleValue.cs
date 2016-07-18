using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the value of a Togggle component")]
	[System.Serializable]
	public class SetToggleValue : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The bool value to set.")]
		public FsmBool value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Toggle component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Toggle>();
			component.isOn= value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			component.isOn= value.Value;
		}
		
	}
}