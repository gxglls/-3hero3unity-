using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the layer's current weight.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Animator.SetLayerWeight.html")]
	[System.Serializable]
	public class SetLayerWeight : AnimatorAction {
		[Tooltip("Layer index containing the destination state.")]
		public FsmInt layer;
		[Tooltip("The weight of the layer.")]
		public FsmFloat weight;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSetLayerWeight ();
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			DoSetLayerWeight ();
		}

		private void DoSetLayerWeight(){
			animator.SetLayerWeight (layer.Value, weight.Value);
		}
	}
}