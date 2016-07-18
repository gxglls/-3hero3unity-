using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("The normalized position in this RectTransform that it rotates around.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform-pivot.html")]
	[System.Serializable]
	public class GetPivot : RectTransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector2 store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.pivot;
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value = transform.pivot;
		}
	}
}