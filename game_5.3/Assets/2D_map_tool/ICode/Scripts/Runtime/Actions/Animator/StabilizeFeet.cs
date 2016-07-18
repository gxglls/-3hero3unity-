using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Automatic stabilization of feet during transition and blending.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-stabilizeFeet.html")]
	[System.Serializable]
	public class StabilizeFeet : AnimatorAction {
		[Tooltip("True to stabilize feet.")]
		public FsmBool stabilize;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private int id;
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoStabilizeFeet ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoStabilizeFeet ();
		}
		
		private void DoStabilizeFeet(){
			animator.stabilizeFeet = stabilize.Value;
		}
	}
}