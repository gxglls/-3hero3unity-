using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Get left foot bottom height.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-leftFeetBottomHeight.html")]
	[System.Serializable]
	public class GetLeftFeetBottomHeight : AnimatorAction {
		[Shared]
		[Tooltip("Store the value.")]
		public FsmFloat store;
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
			store.Value = animator.leftFeetBottomHeight;
		}
	}
}