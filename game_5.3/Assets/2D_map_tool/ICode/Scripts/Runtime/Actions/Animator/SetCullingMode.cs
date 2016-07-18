using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Controls culling of this Animator component.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-cullingMode.html")]
	[System.Serializable]
	public class SetCullingMode : AnimatorAction {
		public AnimatorCullingMode mode;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.cullingMode = mode;
			Finish ();
		}
		
	}
}