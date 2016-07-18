using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(IndentAttribute))]
	public class IndentDrawer : FsmVariableDrawer {
		public override void OnPropertyField (SerializedProperty property, GUIContent label)
		{
			IndentAttribute attribute = fieldInfo.GetAttribute<IndentAttribute> ();
			EditorGUI.indentLevel += attribute.indentLevel;
			base.OnPropertyField (property, label);
			EditorGUI.indentLevel -= attribute.indentLevel;
		}
	}
}