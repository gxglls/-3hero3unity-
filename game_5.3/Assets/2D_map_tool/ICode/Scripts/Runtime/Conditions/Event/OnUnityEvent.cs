using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityEvent{
	[Category(Category.Event)]  
	[Tooltip("Unity messages that are sended.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/MonoBehaviour.html")]
	[System.Serializable]
	public class OnUnityEvent : Condition {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		public UnityEventHandler.EventType type;
		[NotRequired]
		[Shared]
		[Tooltip("Store the other GameObject or self on mouse events.")]
		public FsmGameObject store;

		private UnityEventHandler handler;
		private bool isTrigger;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			handler = gameObject.Value.AddComponent<UnityEventHandler>();	
			handler.type = type;
			handler.onTrigger+=OnTrigger;
		}
		
		public override void OnExit ()
		{
			if (isTrigger) {
				handler.onTrigger -= OnTrigger;
			}
			Destroy (handler);
			isTrigger = false;
		}
		
		private void OnTrigger(GameObject other){
			isTrigger = true;
			store.Value = other;
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