using UnityEngine;
using System.Collections;

namespace ICode.Conditions.UnityAnimator{
	[Category(Category.Animator)]
	[Tooltip("Compare the layer's current weight.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Animator.GetLayerWeight.html")]
	[System.Serializable]
	public class GetLayerWeight: AnimatorCondition {
		[Tooltip("The animator layer to test.")]
		public FsmInt layer;
		[Tooltip("Is the parameter greater or less?")]
		public FloatComparer comparer;
		[Tooltip("Value to test with.")]
		public FsmFloat value;
		
		public override bool Validate ()
		{
			float floatValue = animator.GetLayerWeight (layer.Value);
			return FsmUtility.CompareFloat (floatValue, value.Value, comparer);
		}
	}
}