using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[System.Serializable]
	public abstract class CameraAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;

		protected Camera camera;
		
		public override void OnEnter (){
			camera = gameObject.Value.GetComponent<Camera> ();
		}
	}
}