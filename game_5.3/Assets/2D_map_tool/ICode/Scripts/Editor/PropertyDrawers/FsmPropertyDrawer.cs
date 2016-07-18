using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Linq;
using ICode;
using ICode.Actions;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(FsmPropertyAttribute))]
	public class FsmPropertyDrawer : FsmVariableDrawer {

		public override void OnGUI (SerializedProperty property, GUIContent label)
		{
			SerializedProperty componentProperty = property.serializedObject.FindProperty ("component");
			SerializedProperty propProperty = property.serializedObject.FindProperty ("property");
			SerializedProperty parameterProperty = property.serializedObject.FindProperty ("parameter");

			GUILayout.BeginHorizontal ();
			EditorGUILayout.PropertyField (componentProperty);
			ComponentHint (componentProperty, propProperty);
			GUILayout.EndHorizontal ();

			if (!string.IsNullOrEmpty (componentProperty.stringValue)) {
				Type componentType = TypeUtility.GetType (componentProperty.stringValue);
				if (componentType != null) {
					GUILayout.BeginHorizontal ();
					EditorGUILayout.PropertyField (propProperty);
					PropertyHint (propProperty, componentType);
					GUILayout.EndHorizontal ();
					if (!string.IsNullOrEmpty (propProperty.stringValue)) {
						Type variableType = FsmUtility.GetVariableType (TypeUtility.GetMemberType (componentType, propProperty.stringValue));
						Debug.Log(variableType);
						if(variableType != null){
							fieldInfo = property.serializedObject.targetObject.GetType().GetField ("parameter");
							if(parameterProperty.objectReferenceValue == null || parameterProperty.objectReferenceValue.GetType() != variableType){
								FsmEditorUtility.DestroyImmediate(parameterProperty.objectReferenceValue as FsmVariable);
								FsmVariable variable = ScriptableObject.CreateInstance (variableType) as FsmVariable;
								variable.hideFlags = HideFlags.HideInHierarchy;
								if (EditorUtility.IsPersistent (parameterProperty.serializedObject.targetObject)) {
									AssetDatabase.AddObjectToAsset (variable, property.serializedObject.targetObject);
									AssetDatabase.SaveAssets ();
								}
								variable.IsShared = fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent (variable) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || variable is FsmArray;
								parameterProperty.serializedObject.Update();
								parameterProperty.objectReferenceValue = variable;
								parameterProperty.serializedObject.ApplyModifiedProperties ();
							}

							base.OnGUI (parameterProperty, new GUIContent ("Parameter"));
						}
					}
				}
			}
		}

		private void ComponentHint(SerializedProperty component,SerializedProperty property){
			if (GUILayout.Button (GUIContent.none, "MiniPullDown", GUILayout.Width (15f))) {
				GUI.FocusControl (null);
				FsmGUIUtility.SubclassMenu<Component> (delegate(Type type) {
					component.serializedObject.Update ();
					component.stringValue = type.Name;
					property.stringValue=string.Empty;
					component.serializedObject.ApplyModifiedProperties ();
					ErrorChecker.CheckForErrors ();
				});
				EditorGUIUtility.ExitGUI ();
			}
		}
		
		private void PropertyHint(SerializedProperty property,Type componentType){
			if(GUILayout.Button(GUIContent.none,"MiniPullDown",GUILayout.Width(15))){
				GUI.FocusControl(null);
				GenericMenu toolsMenu = new GenericMenu();
				string[] names= componentType.GetPropertyAndFieldNames(true);
				
				foreach(string s in names){
					string name=s;
					string displayName=s.Split('.').Last();
					toolsMenu.AddItem(new GUIContent(displayName),false,delegate() {
						property.serializedObject.Update ();
						property.stringValue = name;
						property.serializedObject.ApplyModifiedProperties ();
						ErrorChecker.CheckForErrors ();
					});
				}
				toolsMenu.ShowAsContext();
				EditorGUIUtility.ExitGUI();
			}	
		}
	}
}