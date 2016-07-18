using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The position of the pivot of this RectTransform relative to the anchor reference point.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition.html")]
	[System.Serializable]
	public class SetAnchoredPosition : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector2 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.anchoredPosition=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.anchoredPosition=value.Value;
		}
	}
}