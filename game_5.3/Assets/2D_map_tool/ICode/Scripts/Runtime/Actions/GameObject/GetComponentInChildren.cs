using UnityEngine;
using System;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Get the component in children.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Component.GetComponentInChildren.html")]
	[System.Serializable]
	public class GetComponentInChildren : GetComponent {
		public override void OnEnter ()
		{
			componentType = TypeUtility.GetType (component.Value);
			store.Value=gameObject.Value.GetComponentInChildren(componentType);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value=gameObject.Value.GetComponentInChildren(componentType);
		}
	}
}