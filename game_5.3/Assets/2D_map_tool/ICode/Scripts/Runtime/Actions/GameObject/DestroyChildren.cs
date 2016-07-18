using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Destroys all children of the target.")]
	[HelpUrl("http://docs.unity3d.com/Documentation/ScriptReference/Object.Destroy.html")]
	[System.Serializable]
	public class DestroyChildren : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Should inactive children be destroyed?")]
		public FsmBool includeInactive;

		public override void OnEnter ()
		{
			Transform root = gameObject.Value.transform;
			foreach(Transform transform in root){
				Destroy(transform.gameObject);
			}
			Finish ();
		}
	}
}