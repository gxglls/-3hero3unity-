using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The size of this RectTransform relative to the distances between the anchors.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-sizeDelta.html")]
	[System.Serializable]
	public class SetSizeDelta : RectTransformAction {
		[Tooltip("Value to set.")]
		public FsmVector2 value;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.sizeDelta=value.Value;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.sizeDelta=value.Value;
		}
	}
}