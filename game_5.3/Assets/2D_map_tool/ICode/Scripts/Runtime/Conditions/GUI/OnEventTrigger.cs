using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

namespace ICode.Conditions.UnityGUI{
	[Category(Category.GUI)]    
	[System.Serializable]
	public class OnEventTrigger : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		public EventTriggerType type;
		private EventTrigger handler;
		private bool isTrigger;
		
		public override void OnEnter ()
		{
			handler = gameObject.Value.GetComponent<EventTrigger> ();
			if (handler == null) {
				handler = gameObject.Value.AddComponent<EventTrigger>();
			}
			EventTrigger.Entry entry = new EventTrigger.Entry ();
			entry.eventID = type;
			entry.callback.AddListener (OnTrigger);
			handler.triggers.Add (entry);
			
		}
		
		public override void OnExit ()
		{
			isTrigger = false;
		}
		
		private void OnTrigger(BaseEventData data){
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