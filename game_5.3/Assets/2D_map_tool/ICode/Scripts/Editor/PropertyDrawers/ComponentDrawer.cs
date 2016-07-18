using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(ComponentAttribute))]
	public class ComponentDrawer : FsmVariableDrawer {
		public override void OnPropertyField (SerializedProperty property, GUIContent label)
		{
			base.OnPropertyField (property, label);
			if (GUILayout.Button (GUIContent.none, "MiniPullDown",GUILayout.Width(18f))) {
				GUI.FocusControl(null);
				Type mType=fieldInfo.GetAttribute<ComponentAttribute>().Type ?? typeof(Component);
				FsmGUIUtility.SubclassMenu(mType,delegate(Type type){
					property.serializedObject.Update();
					property.stringValue = type.Name;
					property.serializedObject.ApplyModifiedProperties();
					ErrorChecker.CheckForErrors();
				});
				EditorGUIUtility.ExitGUI();		
			}
		}
	}
}