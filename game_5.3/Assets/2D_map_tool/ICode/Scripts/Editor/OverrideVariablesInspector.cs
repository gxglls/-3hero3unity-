using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using UnityEditorInternal;

namespace ICode.FSMEditor{
	[CustomEditor(typeof(OverrideVariables))]
	public class OverrideVariablesInspector : Editor {
		private UnityEditorInternal.ReorderableList setVariablesList;
		private string[] parameterTypeNames; 

		private void OnEnable(){
			parameterTypeNames = SerializedVariable.SupportedTypes.Select(x=>x.Name).ToArray();
			parameterTypeNames = ArrayUtility.Insert<string> (parameterTypeNames, "None", 0);

			setVariablesList = new UnityEditorInternal.ReorderableList(serializedObject, 
			                                       serializedObject.FindProperty("setVariables"), 
			                                       true, true, true, true);
			setVariablesList.elementHeight = EditorGUIUtility.singleLineHeight * 3+10;
	
			setVariablesList.drawElementCallback =  (Rect rect, int index, bool isActive, bool isFocused) => {
				var element = setVariablesList.serializedProperty.GetArrayElementAtIndex(index);
				element.serializedObject.Update();

				SerializedProperty typeProperty=element.FindPropertyRelative("type");
				Type variableType=TypeUtility.GetType(typeProperty.stringValue);
				string variableTypeName=(variableType!= null?variableType.Name:"None");
				rect.y+=2;
				int m = parameterTypeNames.ToList ().FindIndex (x => x == variableTypeName);
				m = Mathf.Clamp (m, 0, int.MaxValue);
				rect.height=EditorGUIUtility.singleLineHeight;
				m = EditorGUI.Popup (rect,"Parameter Type", m, SerializedVariable.DisplayNames);
				string typeName=parameterTypeNames [m];
				typeProperty.stringValue=typeName;
				SerializedProperty nameProperty=element.FindPropertyRelative("name");
				rect.y+=EditorGUIUtility.singleLineHeight+2;
				EditorGUI.PropertyField(rect,nameProperty);
				string propertyName=SerializedVariable.GetPropertyName(variableType);
				SerializedProperty valueProperty=element.FindPropertyRelative(propertyName);
				if(valueProperty != null){
					rect.y+=EditorGUIUtility.singleLineHeight+2;
					EditorGUI.PropertyField(rect,valueProperty,new GUIContent("Value"),true);
				}
				element.serializedObject.ApplyModifiedProperties();
			};
			setVariablesList.drawHeaderCallback = (Rect rect) => {  
				EditorGUI.LabelField(rect, "Override Variables");
			};
			
		}

		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();
			EditorGUILayout.PropertyField (serializedObject.FindProperty ("behaviour"));
			GUILayout.Space (5);
			setVariablesList.DoLayoutList();
			serializedObject.ApplyModifiedProperties ();
		}
	}
}