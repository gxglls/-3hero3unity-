using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCharacterController{
	[System.Serializable]
	public abstract class CharacterControllerAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		
		protected CharacterController controller;
		
		public override void OnEnter ()
		{
			controller = gameObject.Value.GetComponent<CharacterController> ();
		}
	}
}