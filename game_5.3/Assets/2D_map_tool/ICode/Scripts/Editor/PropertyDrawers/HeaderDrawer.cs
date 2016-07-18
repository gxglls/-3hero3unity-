using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(HeaderAttribute))]
	public class HeaderDrawer : FsmVariableDrawer {
		public override void OnGUI (SerializedProperty property, GUIContent label)
		{
			EditorGUILayout.Space ();
			HeaderAttribute attribute = fieldInfo.GetAttribute<HeaderAttribute> ();
			GUILayout.Label (attribute.header, EditorStyles.boldLabel);
			base.OnGUI (property, label);
		}
	}
}