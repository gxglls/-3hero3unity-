using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The 3D position of the pivot of this RectTransform relative to the anchor reference point.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition3D.html")]
	[System.Serializable]
	public class SetAnchoredPosition3D : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector3 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.anchoredPosition3D=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.anchoredPosition3D=value.Value;
		}
	}
}