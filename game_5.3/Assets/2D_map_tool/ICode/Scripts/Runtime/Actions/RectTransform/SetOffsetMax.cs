using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The offset of the upper right corner of the rectangle relative to the upper right anchor.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-offsetMax.html")]
	[System.Serializable]
	public class SetOffsetMax : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector2 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.offsetMax=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.offsetMax=value.Value;
		}
	}
}