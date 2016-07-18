using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The offset of the lower left corner of the rectangle relative to the lower left anchor.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-offsetMin.html")]
	[System.Serializable]
	public class SetOffsetMin : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector2 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.offsetMin=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.offsetMin=value.Value;
		}
	}
}