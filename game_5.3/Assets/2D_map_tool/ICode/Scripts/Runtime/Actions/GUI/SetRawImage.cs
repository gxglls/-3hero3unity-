using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ICode.Actions.UnityGUI{
	[Category(Category.GUI)]    
	[Tooltip("Sets the texture of a RawImage component.")]
	[System.Serializable]
	public class SetRawImage : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Texture to set.")]
		public FsmObject texture;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private RawImage component;
		
		public override void OnEnter ()
		{
			component = gameObject.Value.GetComponent<RawImage>();
			DoSetImage ();
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			DoSetImage ();
		}
		
		private void DoSetImage(){
			component.texture=texture.Value!= null? (Texture)texture.Value:null;
		}
	}
}