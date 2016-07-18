using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the layer's current weight.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetLayerWeight.html")]
	[System.Serializable]
	public class GetLayerWeight : AnimatorAction {
		[Tooltip("Layer index.")]
		public FsmInt layer;
		[Shared]
		[Tooltip("Store the value.")]
		public FsmFloat store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetLayerWeight ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetLayerWeight ();
		}

		private void DoGetLayerWeight(){
			store.Value = animator.GetLayerWeight (layer.Value);
		}
	}
}