using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Linq;
using ArrayUtility=ICode.ArrayUtility;

namespace ICode.FSMEditor{
	[System.Serializable]
	public class ReorderableList {
		public delegate void AddCallbackDelegate();
		public ReorderableList.AddCallbackDelegate onAddCallback;
		public delegate void ElementCallbackDelegate(int index,bool selected);
		public ReorderableList.ElementCallbackDelegate drawElementCallback;
		public delegate void SelectCallbackDelegate(int index);
		public ReorderableList.SelectCallbackDelegate onSelectCallback;
		public delegate void OnHeaderClick();
		public ReorderableList.OnHeaderClick onHeaderClick;
		public delegate void OnBeforeListItems();
		public ReorderableList.OnBeforeListItems onBeforeListItems;
		public delegate void OnHeaderContent(Rect rect);
		public ReorderableList.OnHeaderContent onDrawHeaderContent;
		public delegate void ReorderCallbackDelegate(IList list);
		public ReorderableList.ReorderCallbackDelegate onReorderCallback;
		public delegate void ContextCallbackDelegate(int index);
		public ReorderableList.ContextCallbackDelegate onContextClick;

		private string title;
		private IList items;
		private bool draggable;
		private int selectedIndex;
		private bool isDragging;
		private bool displayAdd;
		private int dragIndex=-1;
		private bool selectFirst;

		public ReorderableList(IList items, string title,bool draggable, bool displayAdd){
			this.title = title;
			this.items = new ArrayList(items);
			this.draggable = draggable;
			this.displayAdd = displayAdd;
		}
		
		public void DoList(){
			if (!selectFirst && onSelectCallback != null) {
				onSelectCallback(selectedIndex);			
				selectFirst=true;		
			}
			if (DoListHeader ()) {
				if(onBeforeListItems != null){
					GUILayout.BeginVertical (FsmEditorStyles.elementBackground, GUILayout.ExpandWidth (true));
					onBeforeListItems();
					GUILayout.EndVertical();
				}
				DoListItems();
			}
		}
		
		public bool DoListHeader(){
			bool foldOut = EditorPrefs.GetBool (title, false);
			Rect rect = GUILayoutUtility.GetRect (new GUIContent (title), FsmEditorStyles.variableHeader, GUILayout.ExpandWidth (true));
			rect.x -= 1;
			rect.width += 2;
			Rect rect2 = new Rect (rect.width-10,rect.y+2,25,25);

			EventType eventType = FsmEditorUtility.ReserveEvent (rect2);
			if (GUI.Button (rect, title, FsmEditorStyles.variableHeader)) {
				if(Event.current.button==0){
					EditorPrefs.SetBool (title, !foldOut);	
				}
				if(Event.current.button == 1 && onHeaderClick != null){
					onHeaderClick();
				}
			}
			
			FsmEditorUtility.ReleaseEvent (eventType);

			if (displayAdd && GUI.Button (rect2,FsmEditorStyles.toolbarPlus,FsmEditorStyles.label) && onAddCallback != null) {
				onAddCallback();
				if(onSelectCallback!= null){
					onSelectCallback(items.Count);
				}
			}

			if (onDrawHeaderContent != null) {
				onDrawHeaderContent(rect);		
			}
			
			return foldOut;
		}

		private Rect draggingLineRect;
		int swapIndex=-1;

		private List<Rect> elementRects = new List<Rect> ();
		private void DoListItems(){
			elementRects.Clear ();
			
			GUILayout.BeginVertical (FsmEditorStyles.elementBackground);
			
			if (items != null && items.Count > 0) {
				for (int i=0; i< items.Count; i++) {
					DrawListElement(i,selectedIndex==i);
					Rect lastRect=GUILayoutUtility.GetLastRect();
					elementRects.Add(lastRect);
					if(isDragging){
						EditorGUIUtility.AddCursorRect (lastRect, MouseCursor.Pan);	
					}
				}
			} else {
				GUILayout.Label("List is Empty");
			}
			GUILayout.Space (2);
			GUILayout.EndVertical ();
			
			DoListEvents (elementRects);
		}
		
		private Rect titleRect;
		private void DoListEvents(List<Rect> rects){
			if (items == null) {
				return;		
			}
			for (int i=0; i< items.Count; i++) {
				Rect elementRect=rects[i];
				
				switch (Event.current.type) {
				case EventType.MouseDown:
					if (elementRect.Contains (Event.current.mousePosition) && Event.current.button == 0) {
						titleRect=elementRect;
						titleRect.height=17;
						selectedIndex=i;
						if (onSelectCallback != null) {
							onSelectCallback (i);
						}
						GUI.FocusControl (title + i);
						if (draggable && items.Count > 1) {
							dragIndex = i;
							isDragging = true;
							draggingLineRect=new Rect(600000,60000,0,0);
							
						}
						Event.current.Use();
					}
					if (elementRect.Contains (Event.current.mousePosition) && Event.current.button == 1) {
						if(onContextClick != null){
							onContextClick(i);
						}
					}
					break;
				case EventType.MouseUp:
					
					if(isDragging){
						isDragging = false;
						Event.current.Use();
					}
					break;
				case EventType.MouseDrag:
					if (elementRect.Contains (Event.current.mousePosition) && Event.current.button == 0 && items.Count > 1 && draggable) {
						if (Event.current.mousePosition.y < elementRect.y + elementRect.height * 0.5f) {
							draggingLineRect = new Rect (elementRect.x, elementRect.y, elementRect.width, 1);
							swapIndex = (dragIndex > i ? i : i - 1);
						}
						if (Event.current.mousePosition.y > elementRect.y + elementRect.height * 0.5f) {
							draggingLineRect = new Rect (elementRect.x, elementRect.y + elementRect.height + 2.0f, elementRect.width, 1);
							swapIndex = (dragIndex > i ? i + 1 : i);
						}
						Event.current.Use();
					}
					break;
				}
			}
			
			EventType eventType=Event.current.type;
			if (eventType != EventType.MouseDown) {
				if (eventType == EventType.Repaint && Event.current.button==0 && isDragging)
				{
					FsmEditorStyles.inspectorTitle.Draw (titleRect, GUIContent.none,true,true,true,true);
				}
			}
			
			if (swapIndex != -1 && !isDragging && draggable && dragIndex != -1) {

				items.MoveTo(dragIndex, swapIndex);
				if(onReorderCallback != null){
					onReorderCallback(items);
				}
				swapIndex=-1;
			}
			
			if (!isDragging) {
				dragIndex=-1;	
			}
		}
		
		private void DrawListElement(int index, bool selected){

			GUILayout.BeginVertical ();
			if(isDragging){
				GUI.backgroundColor=new Color(0,0,0.8f,1f);
				GUI.Box(draggingLineRect,GUIContent.none);
				GUI.backgroundColor=Color.white;
			}
			if(drawElementCallback != null){
				drawElementCallback(index,selected);
			}
			GUILayout.EndVertical ();
		}
	}
}