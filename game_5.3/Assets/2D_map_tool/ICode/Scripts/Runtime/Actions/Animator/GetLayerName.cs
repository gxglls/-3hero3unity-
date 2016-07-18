using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets name of the layer.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetLayerName.html")]
	[System.Serializable]
	public class GetLayerName : AnimatorAction {
		[Tooltip("Layer index.")]
		public FsmInt layer;
		[Shared]
		[Tooltip("Store the value.")]
		public FsmString store;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = animator.GetLayerName (layer.Value);
			Finish ();
		}

	}
}