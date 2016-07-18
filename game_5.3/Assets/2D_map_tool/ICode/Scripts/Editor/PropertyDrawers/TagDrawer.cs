using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(TagAttribute))]
	public class TagDrawer : FsmVariableDrawer {
		public override void OnPropertyField (SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginChangeCheck ();
			string value = EditorGUILayout.TagField (label, property.stringValue);
			if (EditorGUI.EndChangeCheck ()) {
				property.stringValue = value;
			}
		}
	}
}