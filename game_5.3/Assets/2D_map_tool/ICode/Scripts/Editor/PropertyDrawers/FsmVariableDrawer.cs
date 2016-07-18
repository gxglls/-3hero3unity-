using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(FsmVariable))]
	public class FsmVariableDrawer : PropertyDrawer {
		public override void OnGUI (SerializedProperty property, GUIContent label)
		{
			if (property.objectReferenceValue == null) {
				CreateVariable(property);
			}
			if (property.objectReferenceValue == null) {
				return;			
			} 
			SerializedObject serializedObject = new SerializedObject (property.objectReferenceValue);
			serializedObject.Update ();
			GUILayout.BeginHorizontal ();
			
			SerializedProperty nameProperty = serializedObject.FindProperty ("name");
			SerializedProperty valueProperty = serializedObject.FindProperty ("value");
			SerializedProperty sharedProperty = serializedObject.FindProperty ("isShared");
			
			if (EditorUtility.IsPersistent (property.objectReferenceValue) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || fieldInfo.FieldType == typeof(FsmArray)) {
				sharedProperty.boolValue = true;
			}

			Color color = GUI.backgroundColor;
			if (ErrorChecker.HasErrors(property.objectReferenceValue)){
				GUI.backgroundColor = Color.red;
			}

			int variableIndex=-1;
			if (sharedProperty.boolValue) {
				variableIndex = DrawSharedVariable (label, nameProperty);
			}else {
				OnPropertyField(valueProperty,label);
			}
			GUI.backgroundColor = color;

			if (DoSharedToggle(property)) {
				DrawSharedToggle (sharedProperty);
			}
			GUILayout.EndHorizontal ();
			if (variableIndex == 0) {
				nameProperty.stringValue="None";
				if(GUILayout.Button("Click to create a new variable ["+fieldInfo.FieldType.Name+"]","box",GUILayout.ExpandWidth(true))){
					CreateVariable(property.objectReferenceValue.GetType(),fieldInfo.Name);
					nameProperty.stringValue=fieldInfo.Name;
				}

			}
			serializedObject.ApplyModifiedProperties ();
		}

		private FsmVariable CreateVariable(Type type,string name){
			if (FsmEditor.Root != null) {
				FsmVariable variable = (FsmVariable)ScriptableObject.CreateInstance (type);
				variable.Name = name;
				variable.IsShared=true;
				variable.hideFlags = HideFlags.HideInHierarchy;
				FsmEditor.Root.Variables = ArrayUtility.Add<FsmVariable> (FsmEditor.Root.Variables, variable);
				if (EditorUtility.IsPersistent (FsmEditor.Root)) {
					AssetDatabase.AddObjectToAsset (variable, FsmEditor.Root);
					AssetDatabase.SaveAssets ();
				}
				EditorUtility.SetDirty(FsmEditor.Root);
				return variable;
			}
			return null;
		}

		public virtual void OnPropertyField(SerializedProperty property,GUIContent label){
			if(property != null)
				EditorGUILayout.PropertyField (property, label,true);	
		}

		public bool DoSharedToggle(SerializedProperty property){
			if(fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent(property.objectReferenceValue) && fieldInfo.HasAttribute(typeof(SharedPersistentAttribute)) || property.objectReferenceValue is FsmArray){ //|| !property.objectReferenceValue.GetType().GetProperty("Value").PropertyType.IsSerializable){
				return false;
			}		
			return true;	
		}
		
		public int DrawSharedVariable(GUIContent content, SerializedProperty property){
			EditorGUI.BeginChangeCheck ();
			string[] names=null;
			int variablesOfType = GetVariablesOfType(property.serializedObject.targetObject as FsmVariable, out names);
			variablesOfType = EditorGUILayout.Popup(content,variablesOfType, names.ToGUIContent());
			if (EditorGUI.EndChangeCheck ()) {
				property.stringValue = names[variablesOfType];
			}
			return variablesOfType;
		//	Debug.Log (content.text+": "+property.stringValue);
		}
		
		public void DrawSharedToggle(SerializedProperty property){
			EditorGUI.BeginChangeCheck ();
			bool value=EditorGUILayout.Toggle (property.boolValue, EditorStyles.radioButton,GUILayout.Width(15f));
			if (EditorGUI.EndChangeCheck ()) {
				property.boolValue = value;
			}
		}

		public int GetVariablesOfType(FsmVariable variable,out string[] names){
			if (FsmEditor.Root == null) {
				names= new string[0];
				return 0;
			}
			FsmVariable[] variables = FsmEditor.Root.Variables;
			variables = ArrayUtility.AddRange<FsmVariable> (variables, GlobalVariables.GetVariables ());
			int count = 0;
			List<string> strs = new List<string> (){
				"None"
			};
			
			for (int i = 0; i < variables.Length; i++)
			{
				Type propertyType = variables[i].GetType().GetProperty("Value").PropertyType;
				if (variable == null || propertyType.Equals(variable.GetType().GetProperty("Value").PropertyType))
				{
					strs.Add(variables[i].Name);
					if (variable != null  && variables[i].Name.Equals(variable.Name))
					{
						count = strs.Count - 1;
					}
				}
			}
			names = strs.ToArray();
			return count;
		}

		public virtual void CreateVariable(SerializedProperty property){
			FsmVariable variable = ScriptableObject.CreateInstance (fieldInfo.FieldType) as FsmVariable;
			variable.hideFlags = HideFlags.HideInHierarchy;
			DefaultValueAttribute defaultAttribute=fieldInfo.GetAttribute<DefaultValueAttribute>();
			if(defaultAttribute != null){
				variable.SetValue(defaultAttribute.DefaultValue);
			}

			SharedPersistentAttribute sharedPersistantAttribute = fieldInfo.GetAttribute<SharedPersistentAttribute> ();
			if (sharedPersistantAttribute != null && variable.GetType()==typeof(FsmGameObject)) {
				variable.Name="Owner";
			}
			if (EditorUtility.IsPersistent (property.serializedObject.targetObject)) {
				AssetDatabase.AddObjectToAsset (variable, property.serializedObject.targetObject);
				AssetDatabase.SaveAssets ();
			}
			variable.IsShared = fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent (variable) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || fieldInfo.FieldType == typeof(FsmArray);
			property.objectReferenceValue = variable;
			property.serializedObject.ApplyModifiedProperties ();
			ErrorChecker.CheckForErrors();
		}
	}
}