using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Gets the current avatar.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-avatar.html")]
	[System.Serializable]
	public class GetAvatar : AnimatorAction {
		[Shared]
		[Tooltip("Store the avatar.")]
		public FsmObject store;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = animator.avatar;
			Finish ();
		}
		
	}
}