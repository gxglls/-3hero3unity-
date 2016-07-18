using UnityEngine;
using UnityEditor;
using System.Collections;

namespace ICode.FSMEditor{
	[CustomEditor(typeof(ICodeMaster))]
	public class ICodeMasterInspector : Editor {
		public override void OnInspectorGUI ()
		{
			ICodeMaster master = target as ICodeMaster;
			if (master.components == null) {
				master.components=new System.Collections.Generic.List<ICodeMaster.ComponentModel>();
			}
			Component[] components=master.gameObject.GetComponents(typeof(Component));
			for (int i=0; i< components.Length; i++) {
				if(master.components.Find(x=>x.component == components[i])== null && components[i] != master){
					master.components.Add(new ICodeMaster.ComponentModel(components[i],true));
				}
			}
			master.components.RemoveAll (x => x.component == null);

			for (int i=0; i< master.components.Count; i++) {
				if(master.components[i].component != null){
					master.components[i].show=EditorGUILayout.Toggle(master.components[i].component.GetType().Name,master.components[i].show);
					master.components[i].component.hideFlags=master.components[i].show?HideFlags.None:HideFlags.HideInInspector;
				}
			}

			EditorUtility.SetDirty (master);
		}
	}
}