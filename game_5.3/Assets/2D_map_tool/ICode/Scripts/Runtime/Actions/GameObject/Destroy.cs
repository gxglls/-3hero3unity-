using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Removes a gameobject.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Object.Destroy.html")]
	[System.Serializable]
	public class Destroy : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Delay")]
		public FsmFloat delay;
	
		public override void OnEnter ()
		{
			Destroy (gameObject.Value,delay.Value);
			Finish ();
		}
	}
}