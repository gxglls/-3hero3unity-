using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[System.Serializable]
	public abstract class TransformAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		
		protected Transform transform;
		
		public override void OnEnter ()
		{
			transform = gameObject.Value.transform;
		}
	}
}