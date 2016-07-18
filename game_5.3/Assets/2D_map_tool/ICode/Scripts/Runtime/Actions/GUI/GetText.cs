using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Gets the text of a Text component")]
	[System.Serializable]
	public class GetText : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Shared]
		[Tooltip("The string text value.")]
		public FsmString store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Text component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<Text>();
			store.Value=component.text;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value=component.text;
		}
		
	}
}