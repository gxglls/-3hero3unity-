using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The position of the pivot of this RectTransform relative to the anchor reference point.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition.html")]
	[System.Serializable]
	public class GetAnchoredPosition : RectTransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.anchoredPosition;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = transform.anchoredPosition;
		}
	}
}