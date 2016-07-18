using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Whether or not the Camera will use occlusion culling during rendering.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Camera-useOcclusionCulling.html")]
	[System.Serializable]
	public  class UseOcclusionCulling : CameraAction {
		[Tooltip("Value to set.")]
		public FsmBool value;
		
		public override void OnEnter (){
			camera.useOcclusionCulling = value.Value;
			Finish ();
		}
	}
}