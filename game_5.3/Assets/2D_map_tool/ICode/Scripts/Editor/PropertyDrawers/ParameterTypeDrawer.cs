using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using ICode;
using System;

namespace ICode.FSMEditor{
	[CustomDrawer(typeof(ParameterTypeAttribute))]
	public class ParameterTypeDrawer : FsmVariableDrawer {
		private string[] parameterTypeNames; 

		public override void OnGUI (SerializedProperty property, GUIContent label)
		{
			CreateVariable (property);
			if(property.objectReferenceValue != null)
				base.OnGUI (property, label);
		}

		public override void CreateVariable (SerializedProperty property)
		{
			FsmVariable variable = property.objectReferenceValue as FsmVariable;
			if (parameterTypeNames == null) {
				parameterTypeNames = TypeUtility.GetSubTypeNames (typeof(FsmVariable));
				parameterTypeNames = ArrayUtility.Insert<string> (parameterTypeNames, "None", 0);
			}
			int index = parameterTypeNames.ToList ().FindIndex (x => x == (variable!= null?variable.GetType ().ToString ().Split('.').Last():""));
			index = Mathf.Clamp (index, 0, int.MaxValue);

			index = EditorGUILayout.Popup ("Parameter Type", index, parameterTypeNames);

			string typeName=parameterTypeNames [index];
			string variableTypeName = (variable == null ? "None" : variable.GetType ().Name);
			if(typeName != variableTypeName){
				FsmEditorUtility.DestroyImmediate(property.objectReferenceValue as FsmVariable);
				if(typeName != "None"){
					variable = ScriptableObject.CreateInstance (TypeUtility.GetTypeByName(typeName)[0]) as FsmVariable;
					variable.hideFlags = HideFlags.HideInHierarchy;
					if (EditorUtility.IsPersistent (property.serializedObject.targetObject)) {
						AssetDatabase.AddObjectToAsset (variable, property.serializedObject.targetObject);
						AssetDatabase.SaveAssets ();
					}

					variable.IsShared = fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent (variable) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || variable is FsmArray || !variable.GetType().GetProperty("Value").PropertyType.IsSerializable;
					property.serializedObject.Update();
					property.objectReferenceValue = variable;
					property.serializedObject.ApplyModifiedProperties ();
				}
				ErrorChecker.CheckForErrors();
			}
		}

		/*public override void CreateVariable (SerializedProperty property)
		{
			FsmVariable variable = property.objectReferenceValue as FsmVariable;

			ParameterType parameterType=(ParameterType)EditorGUILayout.EnumPopup("Parameter Type",FsmUtility.GetParameterType(variable));

			if(parameterType != FsmUtility.GetParameterType(variable)){
				FsmEditorUtility.DestroyImmediate(property.objectReferenceValue as FsmVariable);
				if(parameterType != ParameterType.None){
					variable = ScriptableObject.CreateInstance (FsmUtility.GetVariableType(parameterType)) as FsmVariable;
					variable.hideFlags = HideFlags.HideInHierarchy;
					if (EditorUtility.IsPersistent (property.serializedObject.targetObject)) {
						AssetDatabase.AddObjectToAsset (variable, property.serializedObject.targetObject);
						AssetDatabase.SaveAssets ();
					}
					
					variable.IsShared = fieldInfo.HasAttribute (typeof(SharedAttribute)) || EditorUtility.IsPersistent (variable) && fieldInfo.HasAttribute (typeof(SharedPersistentAttribute)) || variable is FsmArray;
					property.serializedObject.Update();
					property.objectReferenceValue = variable;
					property.serializedObject.ApplyModifiedProperties ();
				}
				ErrorChecker.CheckForErrors();
			}
		}*/
	}
}