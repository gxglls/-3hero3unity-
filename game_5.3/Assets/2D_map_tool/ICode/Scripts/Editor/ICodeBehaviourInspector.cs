using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ICode.FSMEditor{
	[CustomEditor(typeof(ICodeBehaviour))]
	public class ICodeBehaviourInspector : Editor {
		private bool showVariables;
		private bool showInfo;

		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();

			SerializedProperty property=serializedObject.FindProperty("stateMachine");
			if(property.objectReferenceValue != null){
				StateMachine fsm= property.objectReferenceValue as StateMachine;

				showInfo=EditorGUILayout.Foldout(showInfo,"Info");
				if(showInfo){
					int indent=EditorGUI.indentLevel;
					EditorGUI.indentLevel++;
					GUILayout.Label("StateMachines ("+(fsm.StateMachinesRecursive.Length+1)+")");
					GUILayout.Label("States ("+fsm.StatesRecursive.Length+")");
					GUILayout.Label("Actions ("+fsm.ActionsRecursive.Length+")");
					GUILayout.Label("Variables ("+fsm.VisibleVariables.Length+")");
					EditorGUI.indentLevel=indent;
				}

				showVariables = EditorGUILayout.Foldout (showVariables, "Variables");
				if (showVariables ) {
					FsmVariable[] variables=fsm.VisibleVariables;
					for(int i=0;i<variables.Length;i++){
						SerializedObject obj=new SerializedObject(variables[i]);
						obj.Update();
						EditorGUILayout.PropertyField(obj.FindProperty("value"),new GUIContent(obj.FindProperty("name").stringValue));
						obj.ApplyModifiedProperties();
					}
				}

			}
			bool flag = GUI.enabled;
			GUI.enabled=!(property.objectReferenceValue ==null || !EditorUtility.IsPersistent(property.objectReferenceValue));
			if (GUILayout.Button ("Bind to GameObject")) {
				serializedObject.Update ();
				StateMachine stateMachine=(StateMachine)FsmUtility.Copy((StateMachine)property.objectReferenceValue);
				property.objectReferenceValue=stateMachine;
				serializedObject.ApplyModifiedProperties();
				if(FsmEditor.instance != null){
					FsmEditor.SelectStateMachine(stateMachine);
				}
			}
			GUI.enabled = flag;
			if (GUILayout.Button ("Open in Editor")) {
				FsmEditor.ShowWindow ();
				if(FsmEditor.instance != null){
					FsmEditor.SelectStateMachine((StateMachine)property.objectReferenceValue);
				}
			}
		}
	}
}