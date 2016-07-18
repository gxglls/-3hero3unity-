using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRenderer{
	[System.Serializable]
	public abstract class RendererAction : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Material array index.")]
		public FsmInt index;

		protected Renderer renderer;

		public override void OnEnter ()
		{
			renderer = gameObject.Value.GetComponent<Renderer> ();
		}
	}
}