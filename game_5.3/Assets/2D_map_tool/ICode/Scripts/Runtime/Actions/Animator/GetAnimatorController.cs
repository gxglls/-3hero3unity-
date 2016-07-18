using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("The runtime representation of AnimatorController that controls the Animator.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-runtimeAnimatorController.html")]
	[System.Serializable]
	public class GetAnimatorController : AnimatorAction {
		[Shared]
		[Tooltip("Store the RuntimeAnimatorController.")]
		public FsmObject store;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = animator.runtimeAnimatorController;
			Finish ();
		}
		
	}
}