using UnityEngine;
using UnityEditor;
using System.Collections;
using ICode;

namespace ICode.FSMEditor{
	[CustomEditor(typeof(StateMachine))]
	public class StateMachineInspector : NodeInspector {
		public override void OnEnable(){
			base.OnEnable ();
			EditorApplication.projectWindowItemOnGUI += OnDoubleClick;
		}

		public override void OnDisable(){
			base.OnDisable ();
			EditorApplication.projectWindowItemOnGUI -= OnDoubleClick;

		}

		public override void OnInspectorGUI ()
		{
			if (node.Parent != null) {
				base.OnInspectorGUI();			
			}
		}

		public virtual void OnDoubleClick(string guid,Rect rect){
			if (Event.current.type == EventType.MouseDown && Event.current.clickCount == 2 && rect.Contains (Event.current.mousePosition)) {
				FsmEditor.ShowWindow();
				FsmEditor.SelectStateMachine((StateMachine)target);
			}
		}
	}
}