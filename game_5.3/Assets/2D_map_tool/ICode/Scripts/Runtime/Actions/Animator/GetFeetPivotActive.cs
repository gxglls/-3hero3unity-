using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Blends pivot point between body center of mass and feet pivot. At 0%, the blending point is body center of mass. At 100%, the blending point is feet pivot.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator-feetPivotActive.html")]
	[System.Serializable]
	public class GetFeetPivotActive : AnimatorAction {
		[Shared]
		[Tooltip("Value to set.")]
		public FsmFloat feetPivotActive;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			feetPivotActive.Value= animator.feetPivotActive;
			Finish ();
		}
		
	}
}