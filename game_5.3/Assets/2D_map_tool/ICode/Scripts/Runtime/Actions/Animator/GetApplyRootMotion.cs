using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Should root motion be applied?")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-applyRootMotion.html")]
	[System.Serializable]
	public class GetApplyRootMotion : AnimatorAction {
		[Shared]
		[Tooltip("Store the value.")]
		public FsmBool store;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value=animator.applyRootMotion;
			Finish ();
		}
		
	}
}