using System;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Get all components in the GameObject or any of its parents.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/GameObject.GetComponentsInParent.html")]
	[System.Serializable]
	public class GetComponentsInParent : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Component]
		[InspectorLabel("Component")]
		[Tooltip("The full name of the component. If the component has namespace, you need to add them to the name e.g. UnityEngine.Rigidbody.")]
		public FsmString component;
		[Tooltip("Should inactive Components be included in the found set?")]
		public FsmBool includeInactive;
		[Shared]
		[Tooltip("Store the components into an array.")]
		public FsmArray store;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;
		
		private Type componentType;
		
		public override void OnEnter ()
		{
			componentType = TypeUtility.GetType (component.Value);
			if (componentType != null) {
				store.Value = gameObject.Value.GetComponentsInParent (componentType,includeInactive.IsNone?false:includeInactive.Value);
			}
			if (!everyFrame) {
				Finish ();
			}
		}
		
		public override void OnUpdate ()
		{
			store.Value=gameObject.Value.GetComponentsInParent(componentType,includeInactive.IsNone?false:includeInactive.Value);
		}
	}
}