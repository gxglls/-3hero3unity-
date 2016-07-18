using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(LayerAttribute))]
	public class LayerDrawer : FsmVariableDrawer {
		public override void OnPropertyField (SerializedProperty property, GUIContent label)
		{
			EditorGUI.BeginChangeCheck ();
			int value = EditorGUILayout.LayerField (label, property.intValue);
			if (EditorGUI.EndChangeCheck ()) {
				property.intValue = value;
			}
		}
	}
}