using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Calls the method on every MonoBehaviour in this game object or any of its children.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject.BroadcastMessage.html")]
	[System.Serializable]
	public class BroadcastMessage : SendMessage {
		
		protected override void DoSendMessage(){
			if (parameter != null) {
				gameObject.Value.BroadcastMessage (method.Value, parameter.GetValue (), options);
			} else {
				gameObject.Value.BroadcastMessage(method.Value,options);	
			}
		}
	}
}