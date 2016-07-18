using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Sets the background color of a camera component.")]
	[System.Serializable]
	public  class SetBackgroundColor : CameraAction {
		[Tooltip("Color to to set")]
		public FsmColor color;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter (){
			camera.backgroundColor = color.Value;
			if (!everyFrame) {
				Finish();			
			}
		}

		public override void OnUpdate ()
		{
			camera.backgroundColor = color.Value;
		}
	}
}