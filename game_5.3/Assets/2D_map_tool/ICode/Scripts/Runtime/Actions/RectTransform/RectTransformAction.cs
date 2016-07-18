using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[System.Serializable]
	public abstract class RectTransformAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		
		protected RectTransform transform;
		
		public override void OnEnter ()
		{
			transform = gameObject.Value.GetComponent<RectTransform>();
		}
	}
}