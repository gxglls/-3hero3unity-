using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Specifies the update mode of the Animator.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-updateMode.html")]
	[System.Serializable]
	public class SetUpdateMode : AnimatorAction {
		public AnimatorUpdateMode mode;
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.updateMode = mode;
			Finish ();
		}

	}
}