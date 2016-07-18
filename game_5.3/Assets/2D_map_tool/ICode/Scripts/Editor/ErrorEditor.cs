using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ICode.FSMEditor{
	public class ErrorEditor : EditorWindow {
		public static void ShowWindow()
		{
			ErrorEditor window = EditorWindow.GetWindow<ErrorEditor>("Error Checker");
			Vector2 size = new Vector2(250f, 250f);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}

		private void OnGUI(){
			List<FsmError> errors = ErrorChecker.GetErrors ();
			GUILayout.BeginHorizontal ("box");
			GUILayout.Label ("State Machine");
			GUILayout.Label ("State");
			GUILayout.Label ("Node");
			GUILayout.Label ("Type");
			GUILayout.Label ("Field");
			GUILayout.EndHorizontal ();
			foreach (FsmError error in errors) {
				GUILayout.BeginHorizontal();
				GUILayout.Label(error.StateMachine.Name, GUILayout.Width(Screen.width/5+40));//+" "+error.State.Name+" "+error.ExecutableNode.GetType().Name+" "+ error.Type+" "+error.FieldInfo.Name);			
				GUILayout.Label(error.State.Name,GUILayout.Width(Screen.width/5-15));
				GUILayout.Label(error.ExecutableNode.GetType().Name,GUILayout.Width(Screen.width/5-15));
				GUILayout.Label(error.Type.ToString(),GUILayout.Width(Screen.width/5-17));
				GUILayout.Label(error.FieldInfo.Name,GUILayout.Width(Screen.width/5));
				GUILayout.EndHorizontal();
			}
		}
		
	}
}