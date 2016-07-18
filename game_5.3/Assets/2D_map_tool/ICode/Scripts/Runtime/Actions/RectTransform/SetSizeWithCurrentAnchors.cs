using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityRectTransform{
	[Category(Category.RectTransform)]    
	[Tooltip("Makes the RectTransform calculated rect be a given size on the specified axis.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/RectTransform.SetSizeWithCurrentAnchors.html")]
	[System.Serializable]
	public class SetSizeWithCurrentAnchors : RectTransformAction {
		[Tooltip("The axis to specify the size along.")]
		public RectTransform.Axis axis;
		[Tooltip("The desired size along the specified axis.")]
		public FsmFloat size;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			transform.SetSizeWithCurrentAnchors (axis, size.Value);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			transform.SetSizeWithCurrentAnchors (axis, size.Value);
		}
	}
}