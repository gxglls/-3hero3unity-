using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Button = UnityEngine.UI.Button;

namespace ICode.Conditions.UnityGUI{
	[Category(Category.GUI)]    
	[System.Serializable]
	public class OnClick : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		private Button button;
		private bool isTrigger;
		
		public override void OnEnter ()
		{
			button = gameObject.Value.GetComponent<Button> ();
			if (button == null) {
				button = gameObject.Value.AddComponent<Button>();
			}
			button.onClick.AddListener(OnTrigger);

		}
		
		public override void OnExit ()
		{
			isTrigger = false;
		}
		
		private void OnTrigger(){
			isTrigger = true;
		}
		
		public override bool Validate ()
		{
			if (isTrigger) {
				isTrigger=false;	
				return true;
			}
			return isTrigger;
		}
	}
}