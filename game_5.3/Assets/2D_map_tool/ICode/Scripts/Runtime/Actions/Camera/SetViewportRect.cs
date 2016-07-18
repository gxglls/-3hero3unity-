using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Where on the screen is the camera rendered in normalized coordinates.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Camera-rect.html")]
	[System.Serializable]
	public  class SetViewportRect : CameraAction {
		[Tooltip("Rect to set.")]
		public Rect rect;
		
		public override void OnEnter (){
			camera.rect = rect;
			Finish ();
		}
	}
}