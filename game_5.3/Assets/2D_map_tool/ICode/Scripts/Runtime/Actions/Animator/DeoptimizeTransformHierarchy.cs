using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("This function will recreate all transform hierarchy under GameObject.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimatorUtility.DeoptimizeTransformHierarchy.html")]
	[System.Serializable]
	public class DeoptimizeTransformHierarchy : AnimatorAction {
		public override void OnEnter ()
		{
			base.OnEnter ();
			AnimatorUtility.DeoptimizeTransformHierarchy (gameObject.Value);
			Finish ();
		}
	}
}