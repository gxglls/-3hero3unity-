using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ICode.FSMEditor{
	public class GlobalVariablesEditor : EditorWindow {
		[MenuItem("Window/Zerano Assets/ICode/Global Variables", false, 2)]
		public static void ShowWindow()
		{
			GlobalVariablesEditor window = EditorWindow.GetWindow<GlobalVariablesEditor>(false, "Global Variables");
			window.minSize = new Vector2(295f, 410f);
			UnityEngine.Object.DontDestroyOnLoad (window);
		}

		private Vector2 scroll;
		private string variableGroup="Default";
		private string variableName;
		private Type variableType;
		private string variableTypeString;
		private GlobalVariables globalVariables;

		private void OnGUI(){
			EditorGUILayout.HelpBox ("Global variables can be accessed from all state machines.", MessageType.Info);
			if (globalVariables == null) {
				return;			
			}
			EditorGUIUtility.labelWidth = 84;
			SelectGroup ();
			DrawCreateGUI ();
			DrawVariables ();			
		}

		private void Update(){
			if (globalVariables == null && !EditorApplication.isCompiling) {
				globalVariables = GlobalVariables.Load();
				if (globalVariables == null) {
					if (!System.IO.Directory.Exists(Application.dataPath + "/ICode/Resources")) {
						AssetDatabase.CreateFolder("Assets/ICode", "Resources");
					}	
					globalVariables= AssetCreator.CreateAsset<GlobalVariables>("Assets/ICode/Resources/"+GlobalVariables.assetName+".asset");
					EditorUtility.DisplayDialog("Created GlobalVariables!",
					                            "Do not delete or rename the Resource folder and the GlobalVariables asset.", "Ok");
				}
				Array.Sort(globalVariables.Variables,(a, b) =>  a.Group.CompareTo(b.Group));
			}
		}

		private void DrawVariables(){
			scroll = GUILayout.BeginScrollView (scroll);
			Dictionary<string,List<FsmVariable>> groupParameters = GetGroupVariables ();
			EditorGUIUtility.labelWidth = 110;
			foreach (var kvp in groupParameters) {
				
				bool foldout=EditorPrefs.GetBool(kvp.Key,false);
				bool state=EditorGUILayout.Foldout(foldout,kvp.Key);
				if(state!= foldout){
					EditorPrefs.SetBool(kvp.Key,state);
				}
				if(foldout){
					for (int i=0; i< groupParameters[kvp.Key].Count;i++) {
						FsmVariable parameter=groupParameters[kvp.Key][i];
						if(parameter != null){
							SerializedObject paramObject= new SerializedObject(parameter);
							SerializedProperty prop=paramObject.FindProperty("value");	
							GUILayout.BeginHorizontal();
							GUILayout.Space(16f);
							string name=paramObject.FindProperty("name").stringValue;
							if(parameter is FsmGameObject){
								GUI.changed=false;
								FsmGameObject mParam=parameter as FsmGameObject;
								if(string.IsNullOrEmpty(mParam.ScenePath) ){
									mParam.Value=(GameObject)EditorGUILayout.ObjectField(name,mParam.Value,typeof(UnityEngine.GameObject),true);
								}else{
									GUILayout.Label(name, GUILayout.Width(106));
									GUILayout.Label (mParam.ScenePath, FsmEditorStyles.wrappedLabelLeft);
									GUILayout.FlexibleSpace();
								}
								
								if(GUI.changed){
									if(!EditorUtility.IsPersistent(mParam.Value) && mParam.Value is GameObject){
										mParam.ScenePath=mParam.Value.name+"("+EditorApplication.currentScene+")";
										SetGlobalGameObject mSet=mParam.Value.GetComponent<SetGlobalGameObject>();
										if(mSet == null){
											mSet=mParam.Value.AddComponent<SetGlobalGameObject>();
										}
										mSet.variableName=mParam.Name;
									}
									EditorUtility.SetDirty(mParam);
								}
							}else{
								paramObject.Update();
								if(prop != null){
									EditorGUILayout.PropertyField(prop,new GUIContent(name),true);
								}
								paramObject.ApplyModifiedProperties();
							}
							
							if (GUILayout.Button ("down",EditorStyles.toolbarButton,GUILayout.Width(35))) {
								if(i<groupParameters[kvp.Key].Count){
									int indexToMove=Array.FindIndex(globalVariables.Variables,x=>x.Name==parameter.Name);
									globalVariables.Variables.Move(indexToMove,0);
									EditorUtility.SetDirty(globalVariables);
								}
							}
							if (GUILayout.Button ("up",EditorStyles.toolbarButton,GUILayout.Width(20))) {
								if(i>0){
									int indexToMove=Array.FindIndex(globalVariables.Variables,x=>x.Name==parameter.Name);
									globalVariables.Variables.Move(indexToMove,1);
									EditorUtility.SetDirty(globalVariables);
								}
							}
							
							if (GUILayout.Button (parameter.Group,EditorStyles.toolbarDropDown,GUILayout.Width(54))) {
								GenericMenu menu= new GenericMenu();
								foreach(FsmVariable p in globalVariables.Variables){
									string group=p.Group;
									FsmVariable mParam=parameter;
									menu.AddItem(new GUIContent(group),mParam.Group==group,delegate() {
										mParam.Group=group;
									});
								}
								menu.ShowAsContext();
							}
							
							if(GUILayout.Button(EditorGUIUtility.FindTexture("Toolbar Minus"),"label",GUILayout.Width(20))){
								globalVariables.Variables= ArrayUtility.Remove(globalVariables.Variables,parameter);
								FsmEditorUtility.DestroyImmediate(parameter);;
								EditorUtility.SetDirty(globalVariables);
							}
							
							GUILayout.EndHorizontal();
						}
					}			        
				}
			}
			GUILayout.EndScrollView ();
		}

		private Dictionary<string,List<FsmVariable>> GetGroupVariables(){
			Dictionary<string,List<FsmVariable>> groupVariables = new Dictionary<string, List<FsmVariable>> ();
			foreach (FsmVariable variable in globalVariables.Variables) {
				if(string.IsNullOrEmpty(variable.Group)){
					variable.Group="Default";
				}
				if(!groupVariables.ContainsKey(variable.Group)){
					groupVariables.Add(variable.Group,new List<FsmVariable>(){variable});
				}else{
					groupVariables[variable.Group].Add(variable);
				}			
			}
			return groupVariables;
		}


		private void SelectGroup(){
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Select Group",GUILayout.Width(80));
			if (GUILayout.Button (variableGroup,EditorStyles.toolbarDropDown)) {
				GenericMenu menu= new GenericMenu();
				foreach(FsmVariable parameter in globalVariables.Variables){
					string group=parameter.Group;
					menu.AddItem(new GUIContent(group),variableGroup==group,delegate() {
						variableGroup=group;
						Array.Sort(globalVariables.Variables, (a, b) =>  a.Group.CompareTo(b.Group));
					});
				}
				menu.ShowAsContext();
			}
			variableGroup=EditorGUILayout.TextField (variableGroup);
			GUILayout.EndHorizontal ();
		}

		private void DrawCreateGUI(){
			variableName = EditorGUILayout.TextField ("Name", variableName);
			bool flag = !string.IsNullOrEmpty (variableName);
			if (!flag) {
				EditorGUILayout.HelpBox("Please enter a unique name for the variable before you continue.",MessageType.Warning);		
			}
			
			if (flag) {
				foreach(FsmVariable variable in globalVariables.Variables){
					if(variable != null && variable.Name == variableName){
						flag=false;
					}
				}			
			}
			
			GUI.enabled = flag;
			GUILayout.BeginHorizontal ();
			GUILayout.Label ("Type",GUILayout.Width(80));
			if (variableType == null) {
				variableType=typeof(FsmBool);
				variableTypeString=variableType.Name.Replace ("Fsm", "");
			}
			
			if (GUILayout.Button (variableTypeString,EditorStyles.toolbarDropDown)) {
				FsmGUIUtility.SubclassMenu<FsmVariable>(delegate(Type type){
					variableType=type;
					variableTypeString=variableType.Name.Replace ("Fsm", "");
				});
			}
			
			if (GUILayout.Button ("Add", EditorStyles.toolbarButton,GUILayout.Width(70))) {
				CreateVariable();
			}
			GUILayout.Space (5);
			GUILayout.EndHorizontal ();
			GUILayout.Space (3);
			GUILayout.Box(GUIContent.none,"PopupCurveSwatchBackground",GUILayout.Height(2),GUILayout.ExpandWidth(true));

			if(!flag){
				GUI.enabled=true;
			}
		}

		private void CreateVariable(){
			FsmVariable variable = (FsmVariable)ScriptableObject.CreateInstance (variableType);
			variable.Name = variableName;
			variable.Group = variableGroup;
			variable.hideFlags = HideFlags.HideInHierarchy;

			AssetDatabase.AddObjectToAsset (variable, globalVariables);
			AssetDatabase.SaveAssets();

			globalVariables.Variables =ArrayUtility.Add(globalVariables.Variables,variable);
			EditorUtility.SetDirty (globalVariables);
			
		}
	}
}