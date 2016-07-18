using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Calls the method on every MonoBehaviour in this game object and on every ancestor of the behaviour.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject.SendMessageUpwards.html")]
	[System.Serializable]
	public class SendMessageUpwards : SendMessage {
		
		protected override void DoSendMessage(){
			if (parameter != null) {
				gameObject.Value.SendMessageUpwards (method.Value, parameter.GetValue (), options);
			} else {
				gameObject.Value.SendMessageUpwards(method.Value,options);	
			}
		}
	}
}