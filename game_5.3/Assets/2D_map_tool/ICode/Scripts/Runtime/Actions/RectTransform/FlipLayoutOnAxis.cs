using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("Flips the alignment of the RectTransform along the horizontal or vertical axis, and optionally its children as well.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransformUtility.FlipLayoutOnAxis.html")]
	[System.Serializable]
	public class FlipLayoutOnAxis : RectTransformAction {
		[Tooltip("The axis to flip along. 0 is horizontal and 1 is vertical.")]
		public FsmInt axis;
		[Tooltip("Flips around the pivot if true. Flips within the parent rect if false.")]
		public FsmBool keepPositioning;
		[Tooltip("Flip the children as well?")]
		public FsmBool recursive;

		public override void OnEnter ()
		{
			base.OnEnter ();
			RectTransformUtility.FlipLayoutOnAxis (transform,axis.Value, keepPositioning.Value, recursive.Value);
			Finish ();
		}
		
	
	}
}