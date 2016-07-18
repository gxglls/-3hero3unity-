using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The normalized position in the parent RectTransform that the upper right corner is anchored to.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchorMax.html")]
	[System.Serializable]
	public class SetAnchorMax : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector2 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.anchorMax=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.anchorMax=value.Value;
		}
	}
}