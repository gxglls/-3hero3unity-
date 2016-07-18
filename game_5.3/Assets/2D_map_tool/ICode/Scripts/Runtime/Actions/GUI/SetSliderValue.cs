using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the value of a Slider component")]
	[System.Serializable]
	public class SetSliderValue : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The float value to set.")]
		public FsmFloat value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Slider component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Slider>();
			component.value = value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			component.value = value.Value;
		}
		
	}
}