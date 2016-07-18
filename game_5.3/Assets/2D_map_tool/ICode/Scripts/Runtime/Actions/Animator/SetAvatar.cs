using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Sets the current avatar.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-avatar.html")]
	[System.Serializable]
	public class SetAvatar : AnimatorAction {
		[SharedPersistent]
		[Tooltip("Avatar to set.")]
		public FsmObject avatar;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.avatar=avatar.Value as Avatar;
			Finish ();
		}
		
	}
}