using UnityEngine;
using System.Reflection;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Reflection)]
	[Tooltip("Get a property of a component.")]
	[HelpUrl("")]
	[System.Serializable]
	public class GetProperty : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject to use.")]
		public FsmGameObject gameObject;
		[HideInInspector]
		public string component;
		[FsmProperty]
		public string property;
		[HideInInspector]
		[Shared]
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
			DoGetProperty ();
			if (!everyFrame) {
				Finish ();
			}
		}

		public override void OnUpdate ()
		{
			DoGetProperty ();
		}

		private void DoGetProperty(){
			if (fieldInfo != null) {
				Debug.Log( fieldInfo.GetValue (mComponent));
				parameter.SetValue( fieldInfo.GetValue (mComponent));			
			} else if (propertyInfo != null) {
			 	parameter.SetValue(propertyInfo.GetValue(mComponent,null));
			}
		}
	}
}