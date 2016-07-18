using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using ICode;

namespace ICode.FSMEditor{
	[System.Serializable]
	public class MainToolbar  {
		[SerializeField]
		private bool lockSelection;
		[SerializeField]
		private bool showPreferences;
		
		public MainToolbar(){
			lockSelection = PreferencesEditor.GetBool (Preference.LockSelection);
			showPreferences= PreferencesEditor.GetBool(Preference.ShowPreference);

		}
		
		public void OnGUI(){
			GUILayout.BeginHorizontal (EditorStyles.toolbar);
			SelectGameObject ();
			SelectStateMachine ();
			
			if (GUILayout.Button ("Lock",(lockSelection?(GUIStyle)"TE toolbarbutton" : EditorStyles.toolbarButton), GUILayout.Width (50))) {
				lockSelection=!lockSelection;
				PreferencesEditor.SetBool(Preference.LockSelection,lockSelection);
			}
			
			if (GUILayout.Button ("Tools",EditorStyles.toolbarDropDown, GUILayout.Width (50))) {
				GenericMenu menu= new GenericMenu();
				menu.AddItem(new GUIContent("Global Variables"),false,delegate() {
					GlobalVariablesEditor.ShowWindow();
				});
				menu.AddItem(new GUIContent("Action Browser"),false,delegate() {
					ActionBrowser.ShowWindow();
				});
				menu.AddItem(new GUIContent("Condition Browser"),false,delegate() {
					ConditionBrowser.ShowWindow();
				});
				menu.AddItem(new GUIContent("Error Console"),false,delegate() {
					ErrorEditor.ShowWindow();
				});
				menu.AddItem(new GUIContent("Setup Shortcuts"),false,delegate() {
					SetupShortcutsEditor.ShowWindow();
				});

				menu.AddItem(new GUIContent("Fsm Tool"),false,delegate() {
					FsmTool.ShowWindow();
				});
				menu.ShowAsContext();
			}
			
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button(FsmEditorStyles.popupIcon, (showPreferences?(GUIStyle)"TE toolbarbutton" : EditorStyles.toolbarButton))) {
				showPreferences=!showPreferences;
				PreferencesEditor.SetBool(Preference.ShowPreference,showPreferences);
			}
			

			GUILayout.EndHorizontal ();
		}
		
		private void SelectGameObject(){
			if (GUILayout.Button(FsmEditor.ActiveGameObject != null?FsmEditor.ActiveGameObject.name:"[None Selected]", EditorStyles.toolbarDropDown,GUILayout.Width(100))) {
				GenericMenu toolsMenu = new GenericMenu();
				List<ICodeBehaviour> behaviours=FsmEditorUtility.FindInScene<ICodeBehaviour>();
				foreach(ICodeBehaviour behaviour in behaviours){
					GameObject mGameObject=behaviour.gameObject;
					toolsMenu.AddItem( new GUIContent(behaviour.name),false, delegate() {
						FsmEditor.SelectGameObject(mGameObject);
					});
				}
				toolsMenu.ShowAsContext();
			}
		}
		
		private void SelectStateMachine(){
			GUIContent content = new GUIContent (FsmEditor.Active!= null?FsmEditor.Active.Name:"[None Selected]");
			float width = EditorStyles.toolbarDropDown.CalcSize (content).x;
			width = Mathf.Clamp (width, 100f, width);
			if (GUILayout.Button(content, EditorStyles.toolbarDropDown,GUILayout.Width(width))) {
				GenericMenu toolsMenu = new GenericMenu();
				if(FsmEditor.ActiveGameObject != null){
					foreach(ICodeBehaviour behaviour in FsmEditor.ActiveGameObject.GetComponents<ICodeBehaviour>()){
						SelectStateMachineMenu(behaviour.stateMachine, ref toolsMenu);
					}
				}else if(FsmEditor.Active != null){
					SelectStateMachineMenu(FsmEditor.Active.Root, ref toolsMenu);
				}
				toolsMenu.AddItem( new GUIContent("[Create New]"),false, delegate() {
					StateMachine stateMachine = AssetCreator.CreateAsset<StateMachine> (true);
					if(stateMachine != null){
						stateMachine.Name = stateMachine.name;
						AnyState state = FsmEditorUtility.AddNode<AnyState> (FsmEditor.Center,stateMachine);
						state.color = (int)NodeColor.Aqua;
						state.Name="Any State";
						FsmGameObject gameObject = ScriptableObject.CreateInstance<FsmGameObject> ();
						gameObject.Name="Owner";
						gameObject.hideFlags = HideFlags.HideInHierarchy;
						gameObject.IsHidden = true;
						gameObject.IsShared = true;
						
						stateMachine.Variables = ArrayUtility.Add<FsmVariable> (stateMachine.Variables, gameObject);
						AssetDatabase.AddObjectToAsset (gameObject, stateMachine);
						AssetDatabase.SaveAssets ();

						FsmEditor.SelectStateMachine(stateMachine);
					}
				});
				toolsMenu.ShowAsContext();
			}
		}

		private void SelectStateMachineMenu(StateMachine stateMachine, ref GenericMenu toolsMenu){
			if(stateMachine != null){
				StateMachine[] stateMachines= stateMachine.StateMachinesRecursive;
				
				if(stateMachines.Length > 0){
					toolsMenu.AddItem( new GUIContent(stateMachine.Name+"/"+stateMachine.Name),false, delegate() {
						FsmEditor.SelectStateMachine(stateMachine);
					});
					
					foreach(StateMachine mStateMachine in stateMachines){
						StateMachine kStateMachine=mStateMachine;
						toolsMenu.AddItem( new GUIContent(stateMachine.Name+"/"+kStateMachine.Name),false, delegate() {
							FsmEditor.SelectStateMachine(kStateMachine);
						});
					}
				}else{
					toolsMenu.AddItem( new GUIContent(stateMachine.Name),false, delegate() {
						FsmEditor.SelectStateMachine(stateMachine);
					});
				}
			}
		}
		
	}
}