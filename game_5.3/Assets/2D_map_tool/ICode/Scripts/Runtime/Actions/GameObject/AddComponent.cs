using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.GameObject)]
	[Tooltip("Adds a component class named component to the game object.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/GameObject.AddComponent.html")]
	[System.Serializable]
	public class AddComponent : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Component]
		[Tooltip("The name of the component to add.")]
		public FsmString component;
		[Tooltip("Remove the component on exit of the state.")]
		public FsmBool removeOnExit;
		[Tooltip("Should the component be added even if one already exists.")]
		public FsmBool addIfExists;
		[NotRequired]
		[Shared]
		[Tooltip ("Store the component.")]
		public FsmObject store;

		private Component mComponent;

		public override void OnEnter ()
		{
			if (addIfExists) {
				mComponent = gameObject.Value.AddComponent (TypeUtility.GetType(component.Value));
			} else {
				if(gameObject.Value.GetComponent(component.Value) == null){
					mComponent = gameObject.Value.AddComponent (TypeUtility.GetType(component.Value));
				}
			}
			store.Value=mComponent;		
			Finish ();
		}

		public override void OnExit ()
		{
			if (removeOnExit.Value && mComponent != null) {
				Destroy(mComponent);			
			}

		}
	}
}