using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityTransform{
	[Category(Category.Transform)]    
	[Tooltip("Gets the root of the transform.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Transform-root.html")]
	[System.Serializable]
	public class GetRoot : TransformAction {
		[Shared]
		[Tooltip("Store the result.")]
		public FsmGameObject store;

		public override void OnEnter ()
		{
			base.OnEnter ();
			store.Value = transform.root.gameObject;

		}
	}
}