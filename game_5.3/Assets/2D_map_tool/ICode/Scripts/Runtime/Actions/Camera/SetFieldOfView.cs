using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Sets the field of view of a camera component.")]
	[System.Serializable]
	public  class SetFieldOfView : CameraAction {
		[Tooltip("Value to set.")]
		public FsmFloat fieldOfView;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		public override void OnEnter (){
			camera.fieldOfView = fieldOfView.Value;
			if (!everyFrame) {
				Finish();			
			}
		}
		
		public override void OnUpdate ()
		{
			camera.fieldOfView = fieldOfView.Value;
		}
	}
}