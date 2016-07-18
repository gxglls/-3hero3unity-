using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Sets the rendering path of a camera.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Camera-renderingPath.html")]
	[System.Serializable]
	public  class SetRenderingPath : CameraAction {
		[Tooltip("RenderingPath to set.")]
		public RenderingPath renderingPath;
		
		public override void OnEnter (){
			camera.renderingPath = renderingPath;
			Finish ();
		}
	}
}