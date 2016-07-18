using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ICode.FSMEditor{
	public class SetupShortcutsEditor : EditorWindow {
		public static void ShowWindow()
		{
			SetupShortcutsEditor window = EditorWindow.GetWindow<SetupShortcutsEditor>("Shortcut Setup");
			Vector2 size = new Vector2(300f, 110);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}

		private void OnGUI(){
			EditorGUIUtility.labelWidth = 130;
			DoKeyGUI ("Show Help", "showHelp", KeyCode.F1);
			DoKeyGUI ("Select All", "selectAll", KeyCode.F2);
			DoKeyGUI ("Create State", "createState", KeyCode.F3);
			DoKeyGUI ("Center View", "centerView", KeyCode.Tab);
			DoKeyGUI ("Action Browser", "actionBrowser", KeyCode.F4);
			DoKeyGUI ("Condition Browser", "conditionBrowser", KeyCode.F5);
		}

		private void DoKeyGUI(string label,string key,KeyCode defaultValue){
			GUILayout.BeginHorizontal ();
			FirstKey firstKey = (FirstKey)EditorPrefs.GetInt (key+"1",(int)FirstKey.None);
			FirstKey index1 = (FirstKey)EditorGUILayout.EnumPopup (label, (FirstKey)firstKey,GUILayout.Width(200));
			if (index1 != firstKey) {
				EditorPrefs.SetInt(key+"1",(int)index1);
			}

			GUILayout.Label ("+",GUILayout.Width(17));

			KeyCode keyCode = (KeyCode)EditorPrefs.GetInt (key+"2",(int)defaultValue);
			KeyCode index2 = (KeyCode)EditorGUILayout.EnumPopup (GUIContent.none, (KeyCode)keyCode,GUILayout.Width(70));
			if (index2 != keyCode) {
				EditorPrefs.SetInt(key+"2",(int)index2);
			}
			GUILayout.EndHorizontal ();
		}
	}

	public enum FirstKey {
		None,
		Control,
		Alt,
		Shift,
	}
}