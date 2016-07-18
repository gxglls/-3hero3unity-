using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ICode;
using ICode.Actions;
using ICode.Conditions;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public static class FsmGUIUtility {
		public static void SubclassMenu<T>(Action<Type> del){
			SubclassMenu (typeof(T), del);
		}

		public static void SubclassMenu(Type t,Action<Type> del){
			GenericMenu menu = new GenericMenu ();
			IEnumerable<Type> types = GetSubclassTypes (t);
			foreach (Type type in types) {
				Type mType=type;
				string content=mType.GetCategory();
				if(!string.IsNullOrEmpty(content)){
					content+="/";
				}
				content+=type.Name.Replace("Fsm","");
				menu.AddItem(new GUIContent(content),false,delegate() {
					del(mType);
				});		
			}
			menu.ShowAsContext ();
		}

		private static IEnumerable<Type> GetSubclassTypes<T>(){
			return GetSubclassTypes (typeof(T));
		}

		private static IEnumerable<Type> GetSubclassTypes(Type mType){
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes()) .Where(type => type.IsSubclassOf(mType) && type.IsClass && !type.IsAbstract);		
		}


		public static GUIContent[] ToGUIContent(this string[] labels){
			List<GUIContent> list= new List<GUIContent>();
			for(int i=0; i <labels.Length;i++){
				list.Add(new GUIContent(labels[i]));
			}        
			return list.ToArray();
		}


		private static ExecutableNode executableCopy;
		public static GenericMenu ExecutableContextMenu(ExecutableNode executable, Node node){

			GenericMenu menu = new GenericMenu ();
			if (executable == null) {
				return menu;
			}
			menu.AddItem(new GUIContent("Enable"),executable.IsEnabled,delegate() {
				executable.IsEnabled=!executable.IsEnabled;		
			});

			menu.AddSeparator("");

			menu.AddItem(new GUIContent("Find Script"),false,delegate() {
				MonoScript[] monoScriptArray = (MonoScript[])Resources.FindObjectsOfTypeAll(typeof(MonoScript));
				Selection.activeObject=monoScriptArray.ToList().Find(x=>x.GetClass() == executable.GetType());
				
			});

			menu.AddItem(new GUIContent("Edit Script"),false,delegate() {
				MonoScript[] monoScriptArray = (MonoScript[])Resources.FindObjectsOfTypeAll(typeof(MonoScript));
				Selection.activeObject=monoScriptArray.ToList().Find(x=>x.GetClass() == executable.GetType());
				AssetDatabase.OpenAsset(Selection.activeObject);
				
			});

			menu.AddSeparator("");

			bool moveDown=false;
			int currentIndex = -1;
			if(executable.GetType().IsSubclassOf(typeof(StateAction))){
				State state= node as State;
				currentIndex=Array.IndexOf(state.Actions,executable);
				moveDown=currentIndex+1<state.Actions.Length;
			}else{
				currentIndex=Array.IndexOf(FsmEditor.SelectedTransition.Conditions,executable);
				moveDown=currentIndex+1<FsmEditor.SelectedTransition.Conditions.Length;
			}

			if (currentIndex - 1 >= 0) {
				menu.AddItem (new GUIContent ("Move Up"), false, delegate() {
					if (executable.GetType ().IsSubclassOf (typeof(StateAction))) {
						State state = node as State;
						state.Actions = ArrayUtility.MoveItem (state.Actions, currentIndex, currentIndex - 1);
					} else {
						FsmEditor.SelectedTransition.Conditions = ArrayUtility.MoveItem (FsmEditor.SelectedTransition.Conditions, currentIndex, currentIndex - 1);
					}
					NodeInspector.Dirty ();
				});
			} else {
				menu.AddDisabledItem(new GUIContent("Move Up"));			
			}

			if (moveDown) {
				menu.AddItem (new GUIContent ("Move Down"), false, delegate() {
					if (executable.GetType ().IsSubclassOf (typeof(StateAction))) {
						State state = node as State;
						state.Actions = ArrayUtility.MoveItem (state.Actions, currentIndex, currentIndex + 1);
					} else {
						FsmEditor.SelectedTransition.Conditions = ArrayUtility.MoveItem (FsmEditor.SelectedTransition.Conditions, currentIndex, currentIndex + 1);
					}
					NodeInspector.Dirty ();
				});
			} else {
				menu.AddDisabledItem(new GUIContent("Move Down"));			
			}

			menu.AddSeparator("");

			menu.AddItem(new GUIContent("Copy"),false,delegate() {
				executableCopy=executable;
			});

			if (executableCopy != null) {

				menu.AddItem (new GUIContent ("Paste After"), false, delegate() {
					ExecutableNode dest=FsmUtility.Copy(executableCopy);
					if(dest.GetType().IsSubclassOf(typeof(StateAction))){
						State state= node as State;
						state.Actions=ArrayUtility.Insert<StateAction>(state.Actions,(StateAction)dest,currentIndex+1);
					}else{
						FsmEditor.SelectedTransition.Conditions=ArrayUtility.Insert<Condition>(FsmEditor.SelectedTransition.Conditions,(Condition)dest,currentIndex+1);
					}
					FsmEditorUtility.ParentChilds(node);
					NodeInspector.Dirty();
				});

				menu.AddItem (new GUIContent ("Paste Before"), false, delegate() {
					ExecutableNode dest=FsmUtility.Copy(executableCopy);
					if(dest.GetType().IsSubclassOf(typeof(StateAction))){
						State state= node as State;
						state.Actions=ArrayUtility.Insert<StateAction>(state.Actions,(StateAction)dest,currentIndex);
					}else{
						FsmEditor.SelectedTransition.Conditions=ArrayUtility.Insert<Condition>(FsmEditor.SelectedTransition.Conditions,(Condition)dest,currentIndex);
					}
					FsmEditorUtility.ParentChilds(node);
					NodeInspector.Dirty();
				});


				menu.AddItem (new GUIContent ("Replace"), false, delegate() {
					ExecutableNode dest=FsmUtility.Copy(executableCopy);
					if(dest.GetType().IsSubclassOf(typeof(StateAction))){
						State state= node as State;
						FsmEditorUtility.DestroyImmediate(state.Actions[currentIndex]);
						state.Actions=ArrayUtility.RemoveAt<StateAction>(state.Actions,currentIndex);
						state.Actions=ArrayUtility.Insert<StateAction>(state.Actions,(StateAction)dest,currentIndex);
					}else{
						FsmEditorUtility.DestroyImmediate(FsmEditor.SelectedTransition.Conditions[currentIndex]);
						FsmEditor.SelectedTransition.Conditions=ArrayUtility.RemoveAt<Condition>(FsmEditor.SelectedTransition.Conditions,currentIndex);
						FsmEditor.SelectedTransition.Conditions=ArrayUtility.Insert<Condition>(FsmEditor.SelectedTransition.Conditions,(Condition)dest,currentIndex);
					}

					FsmEditorUtility.ParentChilds(node);
					NodeInspector.Dirty();
				});
			} else {
				menu.AddDisabledItem(new GUIContent ("Paste After"));
				menu.AddDisabledItem(new GUIContent ("Paste Before"));
				menu.AddDisabledItem(new GUIContent ("Replace"));
			}
			menu.AddSeparator("");

			menu.AddItem (new GUIContent ("Remove"), false,delegate() {
				if(executable.GetType().IsSubclassOf(typeof(StateAction))){
					State state= node as State;
					state.Actions = ArrayUtility.Remove<StateAction> (state.Actions, (StateAction)executable);
				}else{
					FsmEditor.SelectedTransition.Conditions=ArrayUtility.Remove<Condition>(FsmEditor.SelectedTransition.Conditions,(Condition)executable);
				}

				FsmEditorUtility.DestroyImmediate(executable);
				NodeInspector.Dirty();
			});

			return menu;
		}

		public static bool NodeTitlebar(ExecutableNode executable,Node node){
			int controlID = EditorGUIUtility.GetControlID (FocusType.Passive);
			GUIContent content = new GUIContent (executable.name.Replace("/","."), executable.GetType ().GetTooltip());
			
			Rect position= GUILayoutUtility.GetRect(GUIContent.none, FsmEditorStyles.inspectorTitle);
			Rect rect = new Rect(position.x + (float)FsmEditorStyles.inspectorTitle.padding.left, position.y + (float)FsmEditorStyles.inspectorTitle.padding.top, 16f, 16f);
			Rect rect1 = new Rect(position.xMax - (float)FsmEditorStyles.inspectorTitle.padding.right - 2f - 16f, rect.y, 16f, 16f);
			Rect rect4 = rect1;
			rect4.x = rect4.x - 18f;
			
			Rect rect2 = new Rect(position.x + 2f + 2f + 16f*2, rect.y, 100f, rect.height)
			{
				xMax = rect4.xMin - 2f
			};
			Rect rect3 = new Rect(position.x + 16f, rect.y, 16f, 16f);
			
			executable.IsEnabled=GUI.Toggle (rect3, executable.IsEnabled,GUIContent.none);
			string url=executable.GetType().GetHelpUrl();
			
			if (ErrorChecker.HasErrors (executable)) {
				Rect rect5 = rect4;
				rect5.y += 1.0f;
				if(!string.IsNullOrEmpty(url)){
					rect5.x = rect5.x - 18f;
					rect2.xMax=rect5.x;
				}
				
				GUI.Label (rect5, FsmEditorStyles.errorIcon, FsmEditorStyles.inspectorTitleText);
			}
			
			if (GUI.Button(rect1, FsmEditorStyles.popupIcon,FsmEditorStyles.inspectorTitleText))
			{
				ExecutableContextMenu(executable,node).ShowAsContext();
			}
			
			if (!string.IsNullOrEmpty(url) && GUI.Button(rect4, FsmEditorStyles.helpIcon,FsmEditorStyles.inspectorTitleText))
			{
				Application.OpenURL(url);
			}
			
			EventType eventType = Event.current.type;
			if (eventType != EventType.MouseDown) {
				if (eventType == EventType.Repaint)
				{
					FsmEditorStyles.inspectorTitle.Draw (position, GUIContent.none, controlID, executable.IsOpen);
					FsmEditorStyles.inspectorTitleText.Draw (rect2, content, controlID, executable.IsOpen);	
				}
			}
			position.width = 15;
			bool flag = DoToggleForward(position,controlID, executable.IsOpen,GUIContent.none,GUIStyle.none);
			if (flag != executable.IsOpen) {
				executable.IsOpen=flag;	
			}
			return flag;
		}
		
		public static bool DoToggleForward(Rect position, int id, bool value, GUIContent content, GUIStyle style)
		{
			Event ev = Event.current;
			if (ev.MainActionKeyForControl(id))
			{
				value = !value;
				ev.Use();
				GUI.changed = true;
			}
			if (EditorGUI.showMixedValue)
			{
				style = "ToggleMixed";
			}
			EventType eventType = ev.type;
			bool flag = (ev.type != EventType.MouseDown ? false : ev.button != 0);
			if (flag)
			{
				ev.type = EventType.Ignore;
			}
			bool flag1 = GUI.Toggle(position, id, (!EditorGUI.showMixedValue ? value : false), content, style);
			if (flag)
			{
				ev.type = eventType;
			}
			else if (ev.type != eventType)
			{
				GUIUtility.keyboardControl = id;
			}
			return flag1;
		}
		
		public static bool MainActionKeyForControl(this Event evt, int controlId)
		{
			if (GUIUtility.keyboardControl != controlId)
			{
				return false;
			}
			bool flag = (evt.alt || evt.shift || evt.command ? true : evt.control);
			if (evt.type == EventType.KeyDown && evt.character == ' ' && !flag)
			{
				evt.Use();
				return false;
			}
			return (evt.type != EventType.KeyDown || evt.keyCode != KeyCode.Space && evt.keyCode != KeyCode.Return && evt.keyCode != KeyCode.KeypadEnter ? false : !flag);
		}

		public static string SearchField(string search, out bool changed, params GUILayoutOption[] options){
			GUILayout.BeginHorizontal ();
			string before = search;
			string after = EditorGUILayout.TextField ("", before, "SearchTextField");
			
			if (GUILayout.Button ("", "SearchCancelButton", GUILayout.Width (18f))) {
				after = string.Empty;
				GUIUtility.keyboardControl = 0;
			}
			GUILayout.EndHorizontal();
			
			changed= before != after;
			
			return after;
		}
	}
}