using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]  
	[Tooltip("Moves the transform in the direction and distance of translation.")]
	[HelpUrl("")]
	[System.Serializable]
	public class Translate : TransformAction {
		[Tooltip("Translation")]
		public FsmVector3 translation;
		[Tooltip("The coordinate space in which to operate.")]
		public Space space;
		[Tooltip("Use this to make your game frame rate independent.")]
		public FsmBool deltaTime;
		
		public override void OnUpdate ()
		{
			if (deltaTime.Value) {
				transform.Translate (translation.Value*Time.deltaTime, space);
			} else {
				transform.Translate (translation.Value, space);
			}
		}
	}
}