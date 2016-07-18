using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Gets the value of a Toggle component.")]
	[System.Serializable]
	public class GetToggleValue : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Toggle component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Toggle>();
			store.Value = component.isOn;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = component.isOn;
		}
		
	}
}