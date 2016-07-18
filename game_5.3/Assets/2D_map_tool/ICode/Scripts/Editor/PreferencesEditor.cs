﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

namespace ICode.FSMEditor{
	public static class PreferencesEditor {
		private const float elementHeight = 21;
		private const float elements = 7;

		private static Dictionary<Preference, bool> preferencesLookup;
		
		public static void DoGUI(Rect position){
			bool show = GetBool (Preference.ShowPreference);
			if (show) {
				GUILayout.BeginArea (position, GUIContent.none, "OL box");
				DrawPreference (Preference.ShowWelcomeWindow, "Show welcome window on start?", true);
				DrawPreference (Preference.ShowStateDescription, "Show state description?", true);
				DrawPreference (Preference.ShowActionTooltips, "Show action tooltips?", true);
				DrawPreference (Preference.ShowVariableTooltips, "Show variable tooltips?", false);
				DrawPreference (Preference.ShowInfo, "Show StateMachine info?", false);
				DrawPreference (Preference.ShowShortcuts, "Show Help?", true);
				DrawPreference (Preference.EnableShortcuts, "Enable Shortcuts", true);
				GUILayout.EndArea ();	
			}
			
		}

		public static float GetHeight(){
			return elements * elementHeight;		
		}
		
		private static void DrawPreference(Preference preference,string label, bool defaultValue){
			GUILayout.BeginHorizontal ();
			bool state = GetBool (preference,defaultValue);
			bool state2 = EditorGUILayout.Toggle (GUIContent.none, state,GUILayout.Width(18));
			if (state != state2) {
				SetBool (preference, state2);
			}
			GUILayout.Label (label,FsmEditorStyles.wrappedLabel);
			GUILayout.EndHorizontal ();
		}
		
		public static bool GetBool(Preference preference){
			if (preferencesLookup == null) {
				preferencesLookup= new Dictionary<Preference, bool>();			
			}
			
			bool value;
			if (!PreferencesEditor.preferencesLookup.TryGetValue(preference, out value))
			{
				value = EditorPrefs.GetBool (preference.ToString());
				PreferencesEditor.preferencesLookup.Add(preference, value);
			}
			
			return value;
		}

		public static bool ToggleBool(Preference preference){
			bool state = PreferencesEditor.GetBool (preference);
			PreferencesEditor.SetBool (preference, !state);
			return !state;

		}
		
		public static bool GetBool(Preference preference,bool defaultValue){
			
			return EditorPrefs.GetBool (preference.ToString(),defaultValue);
		}
		
		public static void SetBool(Preference preference, bool state){
			if (preferencesLookup == null) {
				preferencesLookup= new Dictionary<Preference, bool>();			
			}
			if (preferencesLookup.ContainsKey (preference)) {
				preferencesLookup[preference]=state;			
			}
			EditorPrefs.SetBool (preference.ToString(), state);
		}
	}
	
	public enum Preference{
		ShowPreference,
		ShowActionTooltips,
		ShowVariableTooltips,
		ShowStateDescription,
		ShowWelcomeWindow,
		ShowShortcuts,
		ShowInfo,
		LockSelection,
		CloseActionBrowserOnAdd,
		ActionBrowserShowPreview,
		CloseConditionBrowserOnAdd,
		ConditionBrowserShowPreview,
		EnableShortcuts
	}
}