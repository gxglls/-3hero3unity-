using UnityEngine;

namespace ICode.Actions{
	[System.Serializable]
	public abstract class TweenTransform : TweenAction {
		[SharedPersistent]
		[Tooltip("GamgeObject to use.")]
		public FsmGameObject gameObject;

		protected Transform transform;
	
		public override void OnEnter ()
		{
			transform = gameObject.Value.transform;
		}
	}
}

