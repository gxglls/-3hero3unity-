using UnityEngine;
using System.Reflection;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Reflection)]
	[Tooltip("Set a property of a component.")]
	[HelpUrl("")]
	[System.Serializable]
	public class SetProperty : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[Tooltip("Component to use.")]
		[HideInInspector]
		public string component;
		[FsmProperty]
		public string property;
		[HideInInspector]
		public FsmVariable parameter;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;

		private Component mComponent;
		private FieldInfo fieldInfo;
		private PropertyInfo propertyInfo;

		public override void OnEnter ()
		{
			base.OnEnter ();
			mComponent = gameObject.Value.GetComponent (component);
			fieldInfo = mComponent.GetType ().GetField (property);
			if (fieldInfo == null) {
				propertyInfo= mComponent.GetType().GetProperty(property);		
			}
			DoSetProperty ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoSetProperty ();
		}

		private void DoSetProperty(){
			if (fieldInfo != null) {
				fieldInfo.SetValue (mComponent, parameter.GetValue ());			
			} else if (propertyInfo != null) {
				propertyInfo.SetValue(mComponent,parameter.GetValue(),null);
			}

		}
	}
}