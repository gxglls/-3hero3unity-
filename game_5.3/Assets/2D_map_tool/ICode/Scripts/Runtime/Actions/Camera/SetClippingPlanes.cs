using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Sets the far and near clipping distance.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Camera-farClipPlane.html")]
	[System.Serializable]
	public  class SetClippingPlanes : CameraAction {
		[Tooltip("Distance to set.")]
		public FsmFloat nearClippingPlane;
		[Tooltip("Distance to set.")]
		public FsmFloat farClippingPlane;

		public override void OnEnter (){
			camera.nearClipPlane = nearClippingPlane.Value;
			camera.farClipPlane = farClippingPlane.Value;
			Finish ();
		}
	}
}