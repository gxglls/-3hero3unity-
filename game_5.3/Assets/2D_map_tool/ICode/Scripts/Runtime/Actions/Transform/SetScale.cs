using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]   
	[Tooltip("Set the global scale of the object.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Transform-lossyScale.html")]
	[System.Serializable]
	public class SetScale : TransformAction {
		[Tooltip("Position to set.")]
		public FsmVector3 scale;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter ()
		{
			base.OnEnter ();
			DoSetScale();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetScale ();
		}
		
		private void DoSetScale(){
			transform.localScale = scale.Value;
		}
	}
}