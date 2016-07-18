using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The offset of the lower left corner of the rectangle relative to the lower left anchor.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-offsetMin.html")]
	[System.Serializable]
	public class GetOffsetMin : RectTransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.offsetMin;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = transform.offsetMin;
		}
	}
}