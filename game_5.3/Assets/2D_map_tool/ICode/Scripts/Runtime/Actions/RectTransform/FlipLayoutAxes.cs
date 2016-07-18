using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("Flips the horizontal and vertical axes of the RectTransform size and alignment, and optionally its children as well.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransformUtility.FlipLayoutAxes.html")]
	[System.Serializable]
	public class FlipLayoutAxes : RectTransformAction {
		[Tooltip("Flips around the pivot if true. Flips within the parent rect if false.")]
		public FsmBool keepPositioning;
		[Tooltip("Flip the children as well?")]
		public FsmBool recursive;

		public override void OnEnter ()
		{
			base.OnEnter ();
			RectTransformUtility.FlipLayoutAxes (transform, keepPositioning.Value, recursive.Value);
			Finish ();
		}
		
	
	}
}