using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The offset of the upper right corner of the rectangle relative to the upper right anchor.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-offsetMax.html")]
	[System.Serializable]
	public class GetOffsetMax : RectTransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.offsetMax;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = transform.offsetMax;
		}
	}
}