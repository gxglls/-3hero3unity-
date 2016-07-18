using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The normalized position in the parent RectTransform that the upper right corner is anchored to.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-anchorMax.html")]
	[System.Serializable]
	public class GetAnchorMax : RectTransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.anchorMax;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = transform.anchorMax;
		}
	}
}