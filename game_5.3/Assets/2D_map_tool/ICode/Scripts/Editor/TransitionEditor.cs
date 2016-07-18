using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using System.Reflection;
using System.Linq;
using ICode;
using ICode.Conditions;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	public class TransitionEditor {
		private Editor host;
		private Transition[] transitions;
		private Node node;
		private ReorderableList transitionList;
		private Condition[] conditions;
		private Transition transition;
		private ReorderableList conditionList;
		private static Transition copy;

		public TransitionEditor(Node node, Editor host)
		{
			this.host = host;
			this.node = node;
		}

		public void OnEnable()
		{
			this.ResetTransitionList ();
		}

		public void OnDisable(){
			FsmEditor.SelectTransition (null);
		}

		public void OnInspectorGUI()
		{
			transitionList.DoList ();
			GUILayout.Space (10f);
			conditionList.DoList ();
		}

		public void ResetTransitionList()
		{

			this.transitions = this.node.Transitions;
			this.transitionList = new ReorderableList (this.transitions, "Transition",true, false)
			{
				onDrawHeaderContent = new ReorderableList.OnHeaderContent(this.DrawTransitionHeader),
				drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.OnTransitionElement),
				onSelectCallback = new ReorderableList.SelectCallbackDelegate(this.SelectTransition),
				onContextClick =  new ReorderableList.ContextCallbackDelegate(this.OnTransitionContextClick),
				onReorderCallback=new ReorderableList.ReorderCallbackDelegate(this.OnReorderTransitionList)
			};
			this.ResetConditionList ();

			this.host.Repaint();
			if(FsmEditor.instance != null)
				FsmEditor.instance.Repaint ();
		}

		private void OnReorderTransitionList(IList list){
			list.CopyTo(node.Transitions,0);	
		}

		private void OnTransitionContextClick(int index){
			GenericMenu menu = new GenericMenu ();
			menu.AddItem (new GUIContent("Remove"),false,delegate() {
				FsmEditorUtility.DestroyImmediate(node.Transitions[index]);
				node.Transitions = ArrayUtility.Remove (node.Transitions, transitions [index]);
				this.ResetTransitionList();
			});
			menu.ShowAsContext ();
		}

		private void DrawTransitionHeader(Rect rect){
			GUI.Label (new Rect (rect.width-25, rect.y+3, 50, 20), "Mute");	
		}

		private void OnTransitionElement(int index, bool selected){
			Transition transition = transitions [index];
			Color color = GUI.contentColor;
			GUI.contentColor = selected ? EditorStyles.foldout.focused.textColor : color;
			GUILayout.BeginHorizontal();
			GUILayout.Label (transition.FromNode.Name + " -> " + transition.ToNode.Name, selected?EditorStyles.whiteLabel:EditorStyles.label);
			GUILayout.FlexibleSpace();
			transition.Mute=GUILayout.Toggle(transition.Mute,GUIContent.none,GUILayout.Width(15));
			GUILayout.Space (15f);
			GUILayout.EndHorizontal();
			GUI.contentColor = color;	
		}

		private void SelectTransition(int index){
			this.transition = transitions [index];
			FsmEditor.SelectTransition (this.transition);
			this.ResetConditionList ();
		}

		private void ResetConditionList()
		{
			if (transition == null) {
				return;			
			}
			this.conditions = this.transition.Conditions;
			this.conditionList = new ReorderableList (this.conditions, "Condition", true, true)
			{
				drawElementCallback = new ReorderableList.ElementCallbackDelegate(this.OnConditionElement),
				onReorderCallback = new ReorderableList.ReorderCallbackDelegate(this.OnReorderConditionList),
				onAddCallback = new ReorderableList.AddCallbackDelegate(delegate(){
					FsmGUIUtility.SubclassMenu<Condition> (CreateCondition);		
				}),
				onContextClick=new ReorderableList.ContextCallbackDelegate(delegate(int index){
					FsmGUIUtility.ExecutableContextMenu(conditions[index],node).ShowAsContext();
				}),
				onHeaderClick= new ReorderableList.OnHeaderClick(delegate(){
					GenericMenu menu= new GenericMenu();
					
					if(conditions.Length > 0){
						menu.AddItem(new GUIContent("Copy"),false, delegate {
							copy=transition;
						});
					}else{
						menu.AddDisabledItem(new GUIContent("Copy"));
					}
					if(copy!= null && copy.Conditions.Length>0){
						
						menu.AddItem(new GUIContent("Paste After"),false,delegate() {
							for(int i=0;i< copy.Conditions.Length;i++){
								ExecutableNode dest=FsmUtility.Copy(copy.Conditions[i]);
								transition.Conditions=ArrayUtility.Add<Condition>(transition.Conditions,(Condition)dest);
								FsmEditorUtility.ParentChilds(transition);
								NodeInspector.Dirty();
							}
							
						});
						menu.AddItem(new GUIContent("Paste Before"),false,delegate() {
							for(int i=0;i< copy.Conditions.Length;i++){
								ExecutableNode dest=FsmUtility.Copy(copy.Conditions[i]);
								transition.Conditions=ArrayUtility.Insert<Condition>(transition.Conditions,(Condition)dest,0);
								FsmEditorUtility.ParentChilds(transition);
								NodeInspector.Dirty();
							}
						});
						if(copy != transition){
							menu.AddItem(new GUIContent("Replace"),false,delegate() {
								for(int i=0;i< transition.Conditions.Length;i++){
									FsmEditorUtility.DestroyImmediate(transition.Conditions[i]);
								}
								transition.Conditions= new Condition[0];
								ResetConditionList();
								
								for(int i=0;i< copy.Conditions.Length;i++){
									ExecutableNode dest=FsmUtility.Copy(copy.Conditions[i]);
									transition.Conditions=ArrayUtility.Add<Condition>(transition.Conditions,(Condition)dest);
									FsmEditorUtility.ParentChilds(transition);
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

		private void OnReorderConditionList(IList list){
			list.CopyTo(transition.Conditions,0);	
		}

		private void CreateCondition(Type type){
			Condition condition = (Condition)ScriptableObject.CreateInstance (type);
			condition.name = type.GetCategory () + "." + type.Name;
			condition.hideFlags = HideFlags.HideInHierarchy;
			transition.Conditions = ArrayUtility.Add<Condition> (transition.Conditions, condition);
			if (EditorUtility.IsPersistent (transition)) {
				AssetDatabase.AddObjectToAsset (condition, transition);
				AssetDatabase.SaveAssets ();
			}
			this.ResetConditionList ();
		}

		private void OnConditionElement(int index, bool selected){
			Condition condition = transition.Conditions [index];
			bool enabled = condition.IsEnabled;
			condition.IsOpen = GUIDrawer.ObjectTitlebar (condition, condition.IsOpen,ref enabled, FsmGUIUtility.ExecutableContextMenu(condition,node));
			condition.IsEnabled = enabled;
			if (condition.IsOpen) {
				GUIDrawer.OnGUI(condition);
			}
		}
	}
}