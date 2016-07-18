using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ICode;
using ICode.Actions;
using ICode.Conditions;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	[System.Serializable]
	public class VariableEditor  {
		private const float ElementHeight = 22f;
		[SerializeField]
		private Vector2 scrollPosition;

		public VariableEditor(){
			scrollPosition.y = Mathf.Infinity;	
		}

		private bool DoHeader(){
			bool foldOut = EditorPrefs.GetBool ("FsmVariables", true);
			Rect rect = GUILayoutUtility.GetRect (new GUIContent ("Variables"), FsmEditorStyles.variableHeader, GUILayout.ExpandWidth (true));
			rect.x -= 1;
			rect.width += 2;
			Rect rect2 = new Rect (rect.width-10,rect.y+2,25,25);

			EventType eventType = FsmEditorUtility.ReserveEvent (rect2);
			if (GUI.Button (rect, "Variables", FsmEditorStyles.variableHeader)) {
				if(Event.current.button==0){
					EditorPrefs.SetBool ("FsmVariables", !foldOut);	
				}
			}

			FsmEditorUtility.ReleaseEvent (eventType);

			if (GUI.Button (rect2, FsmEditorStyles.toolbarPlus,FsmEditorStyles.label)) {
				FsmGUIUtility.SubclassMenu<FsmVariable>(CreateVariable);
				Event.current.Use();	
			}
			return foldOut;
		}

		public void DoGUI(Rect position){
			GUILayout.BeginArea (position,EditorStyles.inspectorDefaultMargins);
			GUILayout.FlexibleSpace ();
			GUILayout.BeginVertical ();

			if (DoHeader()) {
				scrollPosition=GUILayout.BeginScrollView(scrollPosition);
				GUILayout.BeginVertical(FsmEditorStyles.elementBackground);

				if(FsmEditor.Root != null && FsmEditor.Root.VisibleVariables.Length > 0){
					for(int i=0; i< FsmEditor.Root.VisibleVariables.Length;i++){
						FsmVariable variable=FsmEditor.Root.VisibleVariables[i];
						DoVariable(variable);
					}
				}else{
					GUILayout.Label("List is Empty");
				}
				GUILayout.EndVertical ();
				GUILayout.EndScrollView();
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		}

		private void DoVariable(FsmVariable variable){
			SerializedObject serializedObject = new SerializedObject (variable);
			SerializedProperty nameProperty = serializedObject.FindProperty ("name");
			SerializedProperty valueProperty = serializedObject.FindProperty ("value");

			GUILayout.BeginHorizontal ();
			serializedObject.Update ();
			string before = nameProperty.stringValue;
			EditorGUILayout.PropertyField(nameProperty,GUIContent.none);
			if (before != nameProperty.stringValue) {
				List<FsmVariable> variables=GetReferencedVariables(FsmEditor.Root,before);
				for(int i=0;i<variables.Count;i++){
					SerializedObject obj= new SerializedObject(variables[i]);
					obj.Update();
					obj.FindProperty("name").stringValue=nameProperty.stringValue;
					obj.ApplyModifiedProperties();
				}
			}

			if (valueProperty != null) {
				if (valueProperty.propertyType == SerializedPropertyType.Boolean) {
					EditorGUILayout.PropertyField (valueProperty, GUIContent.none, GUILayout.Width (17));	
				} else {
					EditorGUILayout.PropertyField (valueProperty, GUIContent.none);
				}
			}
			serializedObject.ApplyModifiedProperties ();
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button (FsmEditorStyles.toolbarMinus,FsmEditorStyles.label)) {
				FsmEditor.Root.Variables=ArrayUtility.Remove<FsmVariable>(FsmEditor.Root.Variables,variable);
				UnityEngine.Object.DestroyImmediate(variable,true);
				AssetDatabase.SaveAssets();
			}
			GUILayout.EndHorizontal ();

		}

		private List<FsmVariable> GetReferencedVariables(StateMachine fsm, string name){
			List<FsmVariable> variables = new List<FsmVariable> ();
			ExecutableNode[] nodes = fsm.ExecutableNodesRecursive;
			for (int i=0; i<nodes.Length; i++) {
				ExecutableNode mNode=nodes[i];
				FieldInfo[] fields = mNode.GetType ().GetPublicFields ();
				for (int k=0; k< fields.Length; k++) {
					FieldInfo fieldInfo=fields[k];
					if (typeof(FsmVariable).IsAssignableFrom (fieldInfo.FieldType)) {
						FsmVariable variable = (FsmVariable)fieldInfo.GetValue (mNode);
						if (variable != null && variable.IsShared && variable.Name==name) {
							variables.Add(variable);
						}
					}
				}
			}
			return variables;
		}

		public float GetEditorHeight(){
			int cnt =  FsmEditor.Root != null?FsmEditor.Root.VisibleVariables.Length:0;
			bool foldOut = EditorPrefs.GetBool ("FsmVariables", false);
			return VariableEditor.ElementHeight + (foldOut?VariableEditor.ElementHeight * cnt + (cnt == 0 ? 1 : 0) * VariableEditor.ElementHeight:0);
		}

		private void CreateVariable(Type type){
			if (FsmEditor.Root != null) {
				FsmVariable variable = (FsmVariable)ScriptableObject.CreateInstance (type);
				variable.Name = "New " + type.Name.Replace ("Fsm", "");
				variable.IsShared=true;
				variable.hideFlags = HideFlags.HideInHierarchy;
				FsmEditor.Root.Variables = ArrayUtility.Add<FsmVariable> (FsmEditor.Root.Variables, variable);
				scrollPosition.y = Mathf.Infinity;
				if (EditorUtility.IsPersistent (FsmEditor.Root)) {
					AssetDatabase.AddObjectToAsset (variable, FsmEditor.Root);
					AssetDatabase.SaveAssets ();
				}
			}
		}
	}
}