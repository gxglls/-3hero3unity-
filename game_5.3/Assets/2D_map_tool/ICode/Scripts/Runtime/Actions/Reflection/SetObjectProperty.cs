using UnityEngine;
using System.Reflection;
using System.Collections;

namespace ICode.Actions{
	[Category(Category.Reflection)]
	[Tooltip("Set a property of an Object.")]
	[HelpUrl("")]
	[System.Serializable]
	public class SetObjectProperty : StateAction {
		[Shared]
		[InspectorLabel("Object")]
		[Tooltip("Object to use.")]
		public FsmObject _object;
		[Tooltip("Component to use.")]
		[HideInInspector]
		public string component;
		[FsmProperty]
		public string property;
		[HideInInspector]
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
				fieldInfo.SetValue (_object.Value, parameter.GetValue ());			
			} else if (propertyInfo != null) {
				propertyInfo.SetValue(_object.Value,parameter.GetValue(),null);
			}

		}
	}
}