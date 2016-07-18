using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Linq;
using ICode;
using ICode.Actions;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(MethodAttribute))]
	public class MethodDrawer : FsmVariableDrawer {
		
		public override void OnGUI (SerializedProperty property, GUIContent label)
		{
			SerializedProperty componentProperty = property.serializedObject.FindProperty ("component");
			SerializedProperty methodProperty = property.serializedObject.FindProperty ("methodName");
			
			GUILayout.BeginHorizontal ();
			EditorGUILayout.PropertyField (componentProperty);
			ComponentHint (componentProperty, methodProperty);
			GUILayout.EndHorizontal ();
			
			if (!string.IsNullOrEmpty (componentProperty.stringValue)) {
				Type componentType = TypeUtility.GetType (componentProperty.stringValue);
				if (componentType != null) {
					GUILayout.BeginHorizontal ();
					EditorGUILayout.PropertyField (methodProperty);
					MethodHint (methodProperty, componentType);
					GUILayout.EndHorizontal ();
				}
			}
		}
		
		private void ComponentHint(SerializedProperty component,SerializedProperty property){
			if (GUILayout.Button (GUIContent.none, "MiniPullDown", GUILayout.Width (15f))) {
				GUI.FocusControl (null);
				FsmGUIUtility.SubclassMenu<Component> (delegate(Type type) {
					component.serializedObject.Update ();
					component.stringValue = type.ToString ();
					property.stringValue=string.Empty;
					component.serializedObject.ApplyModifiedProperties ();
					ErrorChecker.CheckForErrors ();
				});
				EditorGUIUtility.ExitGUI ();
			}
		}
		
		private void MethodHint(SerializedProperty property,Type componentType){
			if(GUILayout.Button(GUIContent.none,"MiniPullDown",GUILayout.Width(15))){
				GUI.FocusControl(null);
				GenericMenu toolsMenu = new GenericMenu();
				string[] names= componentType.GetMethodNames();
				
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