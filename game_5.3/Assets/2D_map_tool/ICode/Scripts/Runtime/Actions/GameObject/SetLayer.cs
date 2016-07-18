using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Sets the GameObject's layer.")]
	[HelpUrl( "https://docs.unity3d.com/Documentation/ScriptReference/GameObject-layer.html")]
	[System.Serializable]
	public class SetLayer : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Layer]
		[Tooltip("The new layer to set.")]
		public FsmInt layer;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		public override void OnEnter ()
		{
			gameObject.Value.layer = layer.Value;
			if (!everyFrame){
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			gameObject.Value.layer = layer.Value;
		}
	}
}