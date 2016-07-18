using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Is the specified AnimatorController layer in a transition.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.IsInTransition.html")]
	[System.Serializable]
	public class IsInTransition : AnimatorAction {
		[Tooltip("Layer index.")]
		public FsmInt layer;
		[Shared]
		[Tooltip("Store the value.")]
		public FsmBool store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoGetInfo ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoGetInfo ();
		}
		
		private void DoGetInfo(){
			store.Value = animator.IsInTransition (layer.Value);
		}
	}
}