using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Rebind all the animated properties and mesh data with the Animator.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.Rebind.html")]
	[System.Serializable]
	public class Rebind : AnimatorAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.Rebind ();
			Finish ();
		}
	}
}