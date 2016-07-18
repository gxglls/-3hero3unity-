using UnityEngine;
using System;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Get the component in parent.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject.GetComponentInParent.html")]
	[System.Serializable]
	public class GetComponentInParent : GetComponent {
		public override void OnEnter ()
		{
			componentType = TypeUtility.GetType (component.Value);
			store.Value = gameObject.Value.GetComponentInParent (componentType);
			
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value=gameObject.Value.GetComponentInParent(componentType);
		}
	}
}