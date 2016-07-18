using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The normalized position in the parent RectTransform that the lower left corner is anchored to.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchorMin.html")]
	[System.Serializable]
	public class SetAnchorMin : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector2 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.anchorMin=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.anchorMin=value.Value;
		}
	}
}