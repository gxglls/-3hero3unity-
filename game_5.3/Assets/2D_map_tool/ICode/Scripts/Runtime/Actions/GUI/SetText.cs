using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the text of a Text component")]
	[System.Serializable]
	public class SetText : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("The string value this text will display.")]
		public FsmString text;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		 
		private Text component;

		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Text>();
			component.text = text.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			component.text = text.Value;
		}
		
	}
}