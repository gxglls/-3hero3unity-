using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;
using System.Linq;
using ICode;
using ICode.Actions;
using System.Collections.Generic;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public class ActionEditor {
		private StateInspector host;
		private StateAction[] actions;
		private State state;
		private ReorderableList actionList;
		private static List<StateAction> copy;
		private static State copyState;

		public ActionEditor(State state, StateInspector host)
		{
			this.host = host;
			this.state = state;
		}
		
		public void OnEnable()
		{
			this.ResetActionList ();
		}
		
		public void OnInspectorGUI()
		{
			actionList.DoList ();
		}
		
		private void ResetActionList()
		{
			this.actions = this.state.Actions;
			this.actionList = new ReorderableList (this.actions, "Action", true, true)
			{
				drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.OnActionElement),
				onReorderCallback = new ReorderableList.ReorderCallbackDelegate(this.OnReorderList),
				onAddCallback = new ReorderableList.AddCallbackDelegate(delegate(){
					FsmGUIUtility.SubclassMenu<StateAction> (CreateAction);		
				}),
				onContextClick=new ReorderableList.ContextCallbackDelegate(delegate(int index){
					FsmGUIUtility.ExecutableContextMenu(actions[index],state).ShowAsContext();
				}),
				onHeaderClick= new ReorderableList.OnHeaderClick(delegate(){
					GenericMenu menu= new GenericMenu();
					
					if(actions.Length > 0){
						menu.AddItem(new GUIContent("Copy"),false, delegate {
							copy=new List<StateAction>(actions);
							copyState=state;
						});
					}else{
						menu.AddDisabledItem(new GUIContent("Copy"));
					}

					if(copy == null){
						copy= new List<StateAction>();
					}

					copy.RemoveAll(x=>x==null);
					if( copy.Count>0){
						
						menu.AddItem(new GUIContent("Paste After"),false,delegate() {
							for(int i=0;i< copy.Count;i++){
								ExecutableNode dest=FsmUtility.Copy(copy[i]);
								state.Actions=ArrayUtility.Add<StateAction>(state.Actions,(StateAction)dest);
								FsmEditorUtility.ParentChilds(state);
								NodeInspector.Dirty();
							}
							
						});
						menu.AddItem(new GUIContent("Paste Before"),false,delegate() {
							for(int i=0;i< copy.Count;i++){
								ExecutableNode dest=FsmUtility.Copy(copy[i]);
								state.Actions=ArrayUtility.Insert<StateAction>(state.Actions,(StateAction)dest,0);
								FsmEditorUtility.ParentChilds(state);
								NodeInspector.Dirty();
							}
						});
						if(copyState != state){
							menu.AddItem(new GUIContent("Replace"),false,delegate() {
								for(int i=0;i< state.Actions.Length;i++){
									FsmEditorUtility.DestroyImmediate(state.Actions[i]);
								}
								state.Actions= new StateAction[0];
								ResetActionList();
								
								for(int i=0;i< copy.Count;i++){
									ExecutableNode dest=FsmUtility.Copy(copy[i]);
									state.Actions=ArrayUtility.Add<StateAction>(state.Actions,(StateAction)dest);
									FsmEditorUtility.ParentChilds(state);
									NodeInspector.Dirty();
								}
							});
						}else{
							menu.AddDisabledItem(new GUIContent("Replace"));
						}
					}else{
						menu.AddDisabledItem(new GUIContent("Paste After"));
						menu.AddDisabledItem(new GUIContent("Paste Before"));
						menu.AddDisabledItem(new GUIContent("Replace"));
					}
					menu.ShowAsContext();
				}),
			};
			this.host.Repaint();
			if(FsmEditor.instance != null)
				FsmEditor.instance.Repaint ();
		}

		private void OnReorderList(IList list){
			list.CopyTo(state.Actions,0);	
		}
	
		private void CreateAction(Type type){
			StateAction action = (StateAction)ScriptableObject.CreateInstance (type);
			action.name = type.GetCategory () + "." + type.Name;
			action.hideFlags = HideFlags.HideInHierarchy;
			state.Actions = ArrayUtility.Add<StateAction> (state.Actions, action);

			if (EditorUtility.IsPersistent (state)) {
				AssetDatabase.AddObjectToAsset (action, state);
				AssetDatabase.SaveAssets ();
			}
			this.ResetActionList ();
		}
		
		private void OnActionElement(int index, bool selected){
			StateAction action = actions [index];
			bool enabled = action.IsEnabled;
			action.IsOpen = GUIDrawer.ObjectTitlebar (action, action.IsOpen,ref enabled, FsmGUIUtility.ExecutableContextMenu(action,state));
			action.IsEnabled = enabled;
			if (action.IsOpen) {
				GUIDrawer.OnGUI(action);
			}
		}
	}
}