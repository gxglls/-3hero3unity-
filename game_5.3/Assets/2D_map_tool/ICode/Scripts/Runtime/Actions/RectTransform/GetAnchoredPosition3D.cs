using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The 3D position of the pivot of this RectTransform relative to the anchor reference point.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchoredPosition3D.html")]
	[System.Serializable]
	public class GetAnchoredPosition3D : RectTransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.anchoredPosition3D;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = transform.anchoredPosition3D;
		}
	}
}