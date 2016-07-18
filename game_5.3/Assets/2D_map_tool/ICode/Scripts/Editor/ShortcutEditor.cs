using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[System.Serializable]
	public class ShortcutEditor  {
		public void DoGUI(Rect position){
			if (PreferencesEditor.GetBool (Preference.ShowShortcuts)) {
				GUILayout.BeginArea (position);
				GUILayout.FlexibleSpace();
				GUILayout.BeginVertical((GUIStyle)"U2D.createRect");
				ShortcutGUI ("Show Help", "showHelp",KeyCode.F1);
				ShortcutGUI ("Select All", "selectAll",KeyCode.F2);
				ShortcutGUI ("Create State", "createState",KeyCode.F3);
				ShortcutGUI ("Center View", "centerView",KeyCode.Tab);
				ShortcutGUI ("Action Browser","actionBrowser",KeyCode.F4);
				ShortcutGUI ("Condition Browser","conditionBrowser",KeyCode.F5);
				GUILayout.EndVertical();
				GUILayout.EndArea ();
			}
		}
		
		
		private void ShortcutGUI(string title,string key,KeyCode defaultValue){
			FirstKey first = (FirstKey)EditorPrefs.GetInt (key + "1", (int)FirstKey.None);
			string shortcut = first != FirstKey.None?first.ToString()+"+":"";

			shortcut=shortcut+((KeyCode)EditorPrefs.GetInt (key + "2", (int)defaultValue)).ToString ();
			GUILayout.BeginHorizontal ();
			GUILayout.Label(title,FsmEditorStyles.shortcutLabel,GUILayout.Width(130));
			GUILayout.Label(shortcut,FsmEditorStyles.shortcutLabel);
			GUILayout.EndHorizontal ();
		}
		
		public void HandleKeyEvents(){
			if (FsmEditor.instance == null || !PreferencesEditor.GetBool(Preference.EnableShortcuts)) {
				return;			
			}
			Event ev = Event.current;
			switch (ev.type) {
			case EventType.KeyUp:
				DoEvents(ev,false);
				break;
			case EventType.MouseUp:
				DoEvents(ev,true);
				break;
			}
		}

		private void DoEvents(Event ev, bool isMouse){
			if (Validate("showHelp",KeyCode.F1,isMouse)) {
				PreferencesEditor.ToggleBool(Preference.ShowShortcuts);
				ev.Use();
			}
			
			if(Validate("centerView",KeyCode.Tab,isMouse)){
				FsmEditor.instance.CenterView();
			}
			
			if(Validate("selectAll",KeyCode.F2,isMouse)){
				FsmEditor.instance.ToggleSelection();
				ev.Use();
			}
			
			if(Validate("createState",KeyCode.F3,isMouse) && FsmEditor.instance != null){
				FsmEditorUtility.AddNode<State>(ev.mousePosition,FsmEditor.Active);
				if(FsmEditor.instance != null){
					FsmEditor.instance.Repaint();
				}
				ev.Use();
			}
			
			if(Validate("actionBrowser",KeyCode.F4,isMouse)){
				ActionBrowser.ShowWindow();
				ev.Use();
			}
			
			if(Validate("conditionBrowser",KeyCode.F5,isMouse)){
				ConditionBrowser.ShowWindow();
				ev.Use();
			}
		}

		private bool Validate(string key, KeyCode defaultKey,bool isMouse){
			return ControlPressed(key) && KeyPressed(key,defaultKey,isMouse);

		}

		private bool KeyPressed(string key, KeyCode defaultKey, bool isMouse){
			return (Event.current.keyCode == (KeyCode)EditorPrefs.GetInt (key+"2", (int)defaultKey)) || isMouse && (KeyCode)EditorPrefs.GetInt (key+"2", (int)defaultKey) == KeyCode.Mouse0;
		}

		private bool ControlPressed(string key){
			FirstKey firstKey=(FirstKey)EditorPrefs.GetInt(key+"1",(int)FirstKey.None);
			switch(firstKey){
			case FirstKey.Alt:
				return Event.current.alt;
			case FirstKey.Control:
				return Event.current.control;
			case FirstKey.Shift:
				return Event.current.shift;
			}
			return true;
		}

	}
}