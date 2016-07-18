using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Gets the text of an InputField component.")]
	[System.Serializable]
	public class GetInputText : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Shared]
		public FsmString store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private InputField component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<InputField>();
			store.Value = component.text;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = component.text;
		}
		
	}
}