using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityCamera{
	[Category(Category.Camera)]   
	[Tooltip("Gets the main camera.")]
	[System.Serializable]
	public  class GetMainCamera : StateAction {
		[Shared]
		[NotRequired]
		[Tooltip("Store the GameObject.")]
		public FsmGameObject gameObject;
		[Shared]
		[NotRequired]
		[Tooltip("Store the Camera.")]
		public FsmObject camera;

		public override void OnEnter (){
			if (!camera.IsNone) 
				camera.Value=Camera.main;			
			if (!gameObject.IsNone) 
				gameObject.Value=Camera.main != null ? Camera.main.gameObject : null;	

			Finish ();
		}
	}
}