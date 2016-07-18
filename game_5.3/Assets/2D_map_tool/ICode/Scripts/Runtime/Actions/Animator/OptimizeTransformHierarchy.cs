using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace ICode.Actions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("This function will remove all transform hierarchy under GameObject, the animator will write directly transform matrices into the skin mesh matrices saving alot of CPU cycles.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/AnimatorUtility.OptimizeTransformHierarchy.html")]
	[System.Serializable]
	public class OptimizeTransformHierarchy : AnimatorAction {
		public string[] exposedTransforms;
		public override void OnEnter ()
		{
			base.OnEnter ();
			AnimatorUtility.OptimizeTransformHierarchy (gameObject.Value,exposedTransforms);
			Finish ();
		}
	}
}