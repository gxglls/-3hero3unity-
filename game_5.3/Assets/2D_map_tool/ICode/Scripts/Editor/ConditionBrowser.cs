using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ICode;
using ICode.Conditions;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public class ConditionBrowser : BaseBrowser {
		public static void ShowWindow()
		{
			ConditionBrowser window = EditorWindow.GetWindow<ConditionBrowser>("Conditions");
			Vector2 size = new Vector2(250f, 250f);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}
		
		protected override GenericMenu SettingsMenu {
			get {
				GenericMenu menu= new GenericMenu();
				menu.AddItem(new GUIContent("Close after adding condition"),PreferencesEditor.GetBool(Preference.CloseConditionBrowserOnAdd,false),delegate() {
					PreferencesEditor.ToggleBool(Preference.CloseConditionBrowserOnAdd);
				});
				menu.AddItem(new GUIContent("Show Preview"),PreferencesEditor.GetBool(Preference.ConditionBrowserShowPreview,true),delegate() {
					PreferencesEditor.ToggleBool(Preference.ConditionBrowserShowPreview);
				});
				return menu;
			}
		}
		
		protected override List<Type> NodeTypes {
			get {
				List<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(Condition))).ToList();
				types.Sort(delegate(Type p1, Type p2) {return p1.GetCategory().CompareTo(p2.GetCategory());});
				return types;
			}
		}
		
		protected override void OnAddNode (Node node, Type type)
		{
			if (FsmEditor.SelectedTransition == null) {
				EditorUtility.DisplayDialog("Could not add node " + type.Name + "!", "Select a transition before you add a condition.", "Cancel");
				return;			
			}
			Condition condition = (Condition)ScriptableObject.CreateInstance (type);
			condition.hideFlags = HideFlags.HideInHierarchy;
			condition.name = type.GetCategory () + "." + type.Name;

			FsmEditor.SelectedTransition.Conditions = ArrayUtility.Add<Condition> (FsmEditor.SelectedTransition.Conditions, condition);

			if (EditorUtility.IsPersistent (FsmEditor.SelectedTransition)) {
				AssetDatabase.AddObjectToAsset (condition, FsmEditor.SelectedTransition);
				AssetDatabase.SaveAssets ();
			}
			
			if(PreferencesEditor.GetBool(Preference.CloseConditionBrowserOnAdd,false)){
				base.Close();
			}
		}
	}
}