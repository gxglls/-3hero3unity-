using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Interrupts the automatic target matching.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.InterruptMatchTarget.html")]
	[System.Serializable]
	public class InterruptMatchTarget : AnimatorAction {
		[Tooltip("Will make the gameobject match the target completely at the next frame.")]
		public FsmBool completeMatch;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			animator.InterruptMatchTarget (completeMatch.Value);
			Finish ();
		}

	}
}