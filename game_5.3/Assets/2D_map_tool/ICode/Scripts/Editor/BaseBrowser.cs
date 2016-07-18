using UnityEngine;
using UnityEditor;
using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using ICode;

namespace ICode.FSMEditor{
	public class BaseBrowser : EditorWindow {
		private string searchString;
		private Vector2 scroll;
		protected virtual GenericMenu SettingsMenu { get; private set;}
		protected virtual List<Type> NodeTypes{ get; private set;}
		[SerializeField]
		private ExecutableNode active;
		private double clickTime;
		private double doubleClickTime = 0.3;
		private Dictionary<string,List<Type>> sortedTypes;

		private void OnEnable(){
			sortedTypes = GetSortedTypes ();
		}
		
		private void Update(){
			if (FsmEditor.instance == null) {
				Close();			
			}		
		}
		
		private void OnDestroy(){
			DestroyActive ();
		}

		private void DestroyActive(){
			FsmEditorUtility.DestroyImmediate(active);
		}

		private void OnGUI(){
			GUILayout.BeginHorizontal ();
			DoSearch ();
			DoSettings ();
			GUILayout.EndHorizontal ();
			GUILayout.Space (2.0f);
			scroll = GUILayout.BeginScrollView (scroll);
			foreach (KeyValuePair<string,List<Type>> kvp in sortedTypes) {
				bool foldout=EditorPrefs.GetBool(kvp.Key,false);
				if(string.IsNullOrEmpty(searchString)){
					if (GUILayout.Button (kvp.Key,(foldout?(GUIStyle)"TE toolbarbutton" : EditorStyles.toolbarButton))) {
						foldout=!foldout;
						EditorPrefs.SetBool(kvp.Key,foldout);
					}
				}else{
					foldout=true;
				}

				if(foldout){
					foreach(Type actionType in kvp.Value){
						if(!string.IsNullOrEmpty(searchString) && !actionType.Name.ToLower().StartsWith(searchString.ToLower())){
							continue;
						}
						Color color = GUI.contentColor;
						GUI.contentColor = (active != null && actionType==active.GetType() ? EditorStyles.foldout.focused.textColor : color);
						
						if(GUILayout.Button(string.IsNullOrEmpty(searchString)?actionType.Name:actionType.GetCategory()+"."+actionType.Name,"label",GUILayout.ExpandWidth(true))){
							DestroyActive();
							
							ExecutableNode node = (ExecutableNode)ScriptableObject.CreateInstance(actionType);
							node.hideFlags=HideFlags.HideAndDontSave;
							node.name = actionType.Name;
							active=node;

							if ((EditorApplication.timeSinceStartup - clickTime) < doubleClickTime){
								if(FsmEditor.Active != null){
									int selectedStatesCount=FsmEditor.SelectionCount;
									if(selectedStatesCount==0){
										EditorUtility.DisplayDialog("Could not add node "+ active.GetType().Name+"!", "Select a state before adding nodes.", "Cancel");
									}else if(selectedStatesCount==1){
										Node selectedNode=FsmEditor.SelectedNodes[0];
										OnAddNode(selectedNode,active.GetType());
										NodeInspector.Dirty();
									}else{
										EditorUtility.DisplayDialog("Could not add node "+ active.GetType().Name+"!", "Select only one state. Adding nodes to multiple states is not supported.", "Cancel");
									}
								}
							}
							
							clickTime = EditorApplication.timeSinceStartup;
						}
						GUI.contentColor=color;
					}
				}
			}	
			GUILayout.EndScrollView ();
			if (active != null) {
				OnPreviewGUI(active);			
			}
		}

		protected virtual bool DoSearch(){
			bool changed;
			searchString=FsmGUIUtility.SearchField (searchString, out changed);
			return changed;
		}

		protected virtual void DoSettings(){
			if(GUILayout.Button(FsmEditorStyles.popupIcon,FsmEditorStyles.browserPopup,GUILayout.Width(20))){
				SettingsMenu.ShowAsContext();
			}
		}

		protected virtual void OnAddNode(Node node, Type type){

		}

		protected virtual void OnPreviewGUI(ExecutableNode node){
			GUIStyle style = new GUIStyle("IN BigTitle");
			style.padding.top=0;
			GUILayout.BeginVertical(style);
			GUILayout.BeginHorizontal();
			GUILayout.Label(node.name,EditorStyles.boldLabel);
			GUILayout.FlexibleSpace();
			GUIStyle labelStyle= new GUIStyle("label");
			labelStyle.contentOffset= new Vector2(0,5);
			if(!string.IsNullOrEmpty(node.GetHelpUrl()) && GUILayout.Button(FsmEditorStyles.helpIcon,labelStyle,GUILayout.Width(20))){
				Application.OpenURL(node.GetHelpUrl());
			}
			GUILayout.EndHorizontal();
			GUILayout.Space(3f);
			GUILayout.Label(node.GetTooltip(),FsmEditorStyles.wrappedLabel);
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();

			Node selectedNode =FsmEditor.SelectionCount>0? FsmEditor.SelectedNodes [0]:null;

			if (GUILayout.Button (selectedNode != null? "Add to state" : "Select one state to add") &&  selectedNode != null) {
				OnAddNode(selectedNode, node.GetType());
				NodeInspector.Dirty();
			}

			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			
			if(PreferencesEditor.GetBool(Preference.ActionBrowserShowPreview,true)){
				EditorGUI.BeginDisabledGroup(true);
				GUIDrawer.OnGUI (node);
				EditorGUI.EndDisabledGroup();
				GUILayout.Space(5);
			}
		}

		private Dictionary<string,List<Type>> GetSortedTypes(){
			List<Type> types = NodeTypes;
			Dictionary<string,List<Type>> sorted = new Dictionary<string, List<Type>> ();
			foreach (Type type in types) {
				string category=type.GetCategory();
				if(!string.IsNullOrEmpty(category)){
					if(sorted.ContainsKey(category)){
						sorted[category].Add(type);
					}else{
						sorted.Add(category,new List<Type>(){type});
					}
				}
			}
			return sorted;
		}
	}
}