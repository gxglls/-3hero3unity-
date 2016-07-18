using UnityEngine;
using System.Reflection;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Reflection)]
	[Tooltip("Get a property of an Object.")]
	[HelpUrl("")]
	[System.Serializable]
	public class GetObjectProperty : StateAction {
		[Shared]
		[InspectorLabel("Object")]
		[Tooltip("Object to use.")]
		public FsmObject _object;
		[InspectorLabel("Type")]
		[HideInInspector]
		public string component;
		[FsmProperty]
		public string property;
		[HideInInspector]
		[Shared]
		public FsmVariable parameter;
		[Tooltip("Execute the action every frame.")]
		public bool everyFrame;


		private FieldInfo fieldInfo;
		private PropertyInfo propertyInfo;

		public override void OnEnter ()
		{
			base.OnEnter ();

			fieldInfo = _object.Value.GetType ().GetField (property);
			if (fieldInfo == null) {
				propertyInfo= _object.Value.GetType().GetProperty(property);		
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
				parameter.SetValue( fieldInfo.GetValue (_object.Value));			
			} else if (propertyInfo != null) {
			 	parameter.SetValue(propertyInfo.GetValue(_object.Value,null));
			}
		}
	}
}