using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("This is used to render parts of the scene selectively.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Camera-cullingMask.html")]
	[System.Serializable]
	public  class SetCullingMask : CameraAction {
		[Tooltip("Mask to set.")]
		public LayerMask cullingMask;

		public override void OnEnter (){
			camera.cullingMask = cullingMask;
			Finish ();
		}
	}
}