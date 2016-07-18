using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomEditor(typeof(Node),true)]
	public class NodeInspector : Editor {
		protected TransitionEditor transitionEditor;
		protected Node node;
		
		public virtual void OnEnable() {
			node = target as Node;
			transitionEditor= new TransitionEditor(node,this);			
			transitionEditor.OnEnable ();
			Undo.undoRedoPerformed += OnUndoRedo;
		}

		private void OnUndoRedo(){
			ErrorChecker.CheckForErrors ();		
		}

		public virtual void OnDisable(){
			transitionEditor.OnDisable ();
		}
		
		public override void OnInspectorGUI (){
			//base.OnInspectorGUI ();
			if (node.Transitions.Length > 0) {
				transitionEditor.OnInspectorGUI ();
			}
		
		}
		
		protected override void OnHeaderGUI (){
			GUILayout.BeginVertical ("IN BigTitle");
			EditorGUIUtility.labelWidth = 50;
			
			GUILayout.BeginHorizontal ();
			
			node.Name = EditorGUILayout.TextField ("Name", node.Name);
			if (node.GetType() == typeof(State) && !node.IsStartNode) {
				GUIStyle style = FsmEditorStyles.GetNodeStyle (node.color, false,false);
				Rect rect = GUILayoutUtility.GetRect (25, 17, style);
				rect.y += 1;
				if (GUI.Button (rect, GUIContent.none, style)) {
					GenericMenu menu = new GenericMenu ();
					foreach (NodeColor color in System.Enum.GetValues(typeof(NodeColor))) {
						if(color != NodeColor.Aqua && color != NodeColor.Orange){
							int mColor = (int)color;
							menu.AddItem (new GUIContent (color.ToString ()), node.color == mColor, delegate() {
								node.color = mColor;
							});
						}
					}
					menu.ShowAsContext ();
				}
			}
			GUILayout.EndHorizontal ();
			GUILayout.Label("Description:");
			node.comment = EditorGUILayout.TextArea (node.comment, GUILayout.MinHeight (45));
			GUILayout.EndVertical ();
			
			if (GUI.changed) {
				EditorUtility.SetDirty(node);	
				FsmEditor.RepaintAll();
			}
		}

		public static void Dirty(){
			NodeInspector[] editors = (NodeInspector[])Resources.FindObjectsOfTypeAll(typeof(NodeInspector));
			foreach(NodeInspector inspector in editors){
				inspector.MarkDirty();
			}		
			ErrorChecker.CheckForErrors ();	
		}
		
		protected virtual void MarkDirty(){
			transitionEditor.OnEnable ();

		}
	
	}
}