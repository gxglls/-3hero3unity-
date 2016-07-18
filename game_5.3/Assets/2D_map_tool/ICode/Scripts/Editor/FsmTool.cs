using UnityEngine;
using UnityEditor;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

//TODO
namespace ICode.FSMEditor{
	public class FsmTool : EditorWindow {
		public static FsmTool ShowWindow()
		{
			FsmTool window = EditorWindow.GetWindow<FsmTool>("FsmTool");
			return window;
		}

		[SerializeField]
		private StateMachine[] fsms;
		
		private void OnEnable(){
		//	fsms = GetAssetsOfType<StateMachine> (".asset");
		}
		
		private void OnGUI(){

		}

		public static T[] GetAssetsOfType<T>(string fileExtension)
		{
			List<T> tempObjects = new List<T>();
			DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
			FileInfo[] goFileInfo = directory.GetFiles("*" + fileExtension, SearchOption.AllDirectories);
			
			int i = 0; int goFileInfoLength = goFileInfo.Length;
			FileInfo tempGoFileInfo; string tempFilePath;
			Object tempGO;
			for (; i < goFileInfoLength; i++)
			{
				tempGoFileInfo = goFileInfo[i];
				if (tempGoFileInfo == null)
					continue;
				
				tempFilePath = tempGoFileInfo.FullName;
				tempFilePath = tempFilePath.Replace(@"\", "/").Replace(Application.dataPath, "Assets");
				
				Debug.Log(tempFilePath + "\n" + Application.dataPath);
				
				tempGO = AssetDatabase.LoadAssetAtPath(tempFilePath, typeof(Object));
				if (tempGO == null)
				{
					Debug.LogWarning("Skipping Null");
					continue;
				}
				else if (tempGO.GetType() != typeof(T))
				{
					Debug.LogWarning("Skipping " + tempGO.GetType().ToString());
					continue;
				}
				
				tempObjects.Add((T)(object)tempGO);
			}
			
			return tempObjects.ToArray();
		}
	}
}