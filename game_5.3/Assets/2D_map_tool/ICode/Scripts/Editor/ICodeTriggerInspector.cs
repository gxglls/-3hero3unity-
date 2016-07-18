using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;

namespace ICode{
	[CustomEditor(typeof(ICodeTrigger))]
	public class ICodeTriggerInspector : Editor {

		private ReorderableList list;
		private SerializedProperty tag;
		private SerializedProperty radius;
		private SerializedProperty color;

		private void OnEnable(){
			tag = serializedObject.FindProperty ("triggerTag");
			radius = serializedObject.FindProperty ("radius");
			color = serializedObject.FindProperty ("color");
			list = new ReorderableList(serializedObject, serializedObject.FindProperty("components"), true, true, true, true);
			
			list.drawHeaderCallback = (Rect rect) => {  
				EditorGUI.LabelField(rect, "Components");
			};
			
			list.drawElementCallback =  (Rect rect, int index, bool isActive, bool isFocused) => {
				
				var element = list.serializedProperty.GetArrayElementAtIndex(index);
				rect.y += 2;
				EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width-20, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("mObject"), GUIContent.none);
				EditorGUI.PropertyField(new Rect(rect.width+20, rect.y, 20, EditorGUIUtility.singleLineHeight),element.FindPropertyRelative("enable"), GUIContent.none);
			};
		}
		
		public override void OnInspectorGUI ()
		{
			serializedObject.Update ();
			tag.stringValue = EditorGUILayout.TagField ("Trigger Tag", tag.stringValue);
			EditorGUILayout.PropertyField (radius);
			EditorGUILayout.PropertyField (color);
			GUILayout.Space (5);

			list.DoLayoutList ();
			serializedObject.ApplyModifiedProperties ();
		}

		private void OnSceneGUI () {
			ICodeTrigger trigger = target as ICodeTrigger;
			Handles.color = trigger.color;
			Handles.DrawSolidDisc(trigger.transform.position, Vector3.up, radius.floatValue);
			Handles.color = Color.blue;
			serializedObject.Update ();
			radius.floatValue = 
				Handles.ScaleValueHandle(radius.floatValue,
				                         trigger.transform.position + new Vector3(radius.floatValue,0,0),
				                         Quaternion.identity,
				                         2,
				                         Handles.CubeCap,
				                         2);
			serializedObject.ApplyModifiedProperties ();
		}
	}
}