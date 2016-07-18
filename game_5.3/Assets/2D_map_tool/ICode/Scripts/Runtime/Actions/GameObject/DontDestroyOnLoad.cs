using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Makes the object target not be destroyed automatically when loading a new scene.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Object.DontDestroyOnLoad.html")]
	[System.Serializable]
	public class DontDestroyOnLoad : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		public override void OnEnter ()
		{
			GameObject.DontDestroyOnLoad (gameObject.Value);
			Finish ();
		}
	}
}