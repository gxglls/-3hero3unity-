using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("Set the distance of this rectangle relative to a specified edge of the parent rectangle, while also setting its size.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform.SetInsetAndSizeFromParentEdge.html")]
	[System.Serializable]
	public class SetInsetAndSizeFromParentEdge : RectTransformAction {
		[Tooltip("The edge of the parent rectangle to inset from.")]
		public RectTransform.Edge edge;
		[Tooltip("The inset distance.")]
		public FsmFloat inset;
		[Tooltip("The size of the rectangle along the same direction of the inset.")]
		public FsmFloat size;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.SetInsetAndSizeFromParentEdge (edge,inset.Value, size.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.SetInsetAndSizeFromParentEdge (edge,inset.Value, size.Value);
		}
	}
}