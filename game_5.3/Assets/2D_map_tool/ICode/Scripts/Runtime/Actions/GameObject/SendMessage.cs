using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Invoke the method on every MonoBehaviour in this GameObject.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject.SendMessage.html")]
	[System.Serializable]
	public class SendMessage : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Name of the method to call.")]
		public FsmString method;
		[ParameterType]
		[Tooltip("Parameter to send.")]
		public FsmVariable parameter;
		[Tooltip("Should an error be raised if the method doesn't exist on the target object?")]
		public SendMessageOptions options;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			DoSendMessage ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSendMessage ();
		}
		
		protected virtual void DoSendMessage(){
			if (parameter != null) {
				gameObject.Value.SendMessage (method.Value, parameter.GetValue (), options);
			} else {
				gameObject.Value.SendMessage(method.Value,options);	
			}
		}
	}
}