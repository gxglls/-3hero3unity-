using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the text of an InputField component.")]
	[System.Serializable]
	public class SetInputText : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Text to set.")]
		public FsmString text;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private InputField component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<InputField>();
			component.text=text.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			component.text=text.Value;
		}
		
	}
}