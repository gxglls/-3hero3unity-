using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ICode;
using ICode.Actions;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public class ActionBrowser : BaseBrowser {
		public static void ShowWindow()
		{
			ActionBrowser window = EditorWindow.GetWindow<ActionBrowser>("Actions");
			Vector2 size = new Vector2(250f, 250f);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}

		protected override GenericMenu SettingsMenu {
			get {
				GenericMenu menu= new GenericMenu();
				menu.AddItem(new GUIContent("Close after adding action"),PreferencesEditor.GetBool(Preference.CloseActionBrowserOnAdd,false),delegate() {
					PreferencesEditor.ToggleBool(Preference.CloseActionBrowserOnAdd);
				});
				menu.AddItem(new GUIContent("Show Preview"),PreferencesEditor.GetBool(Preference.ActionBrowserShowPreview,true),delegate() {
					PreferencesEditor.ToggleBool(Preference.ActionBrowserShowPreview);
				});
				return menu;
			}
		}

		protected override List<Type> NodeTypes {
			get {
				List<Type> types= AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(typeof(StateAction))).ToList();
				types.Sort(delegate(Type p1, Type p2) {return p1.GetCategory().CompareTo(p2.GetCategory());});
				return types;
			}
		}

		protected override void OnAddNode (Node node, Type type)
		{
			if(!typeof(State).IsAssignableFrom(node.GetType())){
				EditorUtility.DisplayDialog("Could not add node " + type.Name + "!", "You can only add actions to a state.", "Cancel");
				return;
			}

			State state = node as State;
			StateAction action = (StateAction)ScriptableObject.CreateInstance (type);
			action.hideFlags = HideFlags.HideInHierarchy;
			action.name = type.GetCategory () + "." + type.Name;
			state.Actions = ArrayUtility.Add<StateAction> (state.Actions, action);
			if (EditorUtility.IsPersistent (state)) {
				AssetDatabase.AddObjectToAsset (action, state);
				AssetDatabase.SaveAssets ();
			}

			if(PreferencesEditor.GetBool(Preference.CloseActionBrowserOnAdd,false)){
				base.Close();
			}
		}
	}
}