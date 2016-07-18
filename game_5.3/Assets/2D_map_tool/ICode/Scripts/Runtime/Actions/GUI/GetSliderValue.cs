using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Gets the value of a Slider component")]
	[System.Serializable]
	public class GetSliderValue : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Shared]
		[Tooltip("The float value to get.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Slider component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Slider>();
			store.Value = component.value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = component.value;
		}
		
	}
}