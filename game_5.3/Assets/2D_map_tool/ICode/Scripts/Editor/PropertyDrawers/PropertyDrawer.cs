using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;
using ICode;

namespace ICode.FSMEditor{
	public class PropertyDrawer{
		public FieldInfo fieldInfo;

		public virtual void OnGUI(SerializedProperty property, GUIContent label){
		}
	}
}