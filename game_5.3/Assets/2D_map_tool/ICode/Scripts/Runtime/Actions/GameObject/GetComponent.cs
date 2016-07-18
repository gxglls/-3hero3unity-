using UnityEngine;
using System;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Get the component.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject.GetComponent.html")]
	[System.Serializable]
	public class GetComponent : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Component]
		[Tooltip("The name of the component.")]
		public FsmString component;
		[Shared]
		[Tooltip("Store the component.")]
		public FsmObject store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		protected Type componentType;
		public override void OnEnter ()
		{
			componentType=TypeUtility.GetType(component.Value);
			store.Value=gameObject.Value.GetComponent(componentType);
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value=gameObject.Value.GetComponent(componentType);
		}
	}
}