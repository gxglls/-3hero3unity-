using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace ICode.FSMEditor{
	public class MonoBehaviourConverter : EditorWindow {
		public static void ShowWindow()
		{
			MonoBehaviourConverter window = EditorWindow.GetWindow<MonoBehaviourConverter>("Converter");
			Vector2 size = new Vector2(250f, 250f);
			window.minSize = size;
			UnityEngine.Object.DontDestroyOnLoad (window);
		}
		private Vector2 scroll;
		private MonoScript script; 
		private string outputText=string.Empty;
		private string inputText=string.Empty;

		private void OnGUI(){
			GUILayout.BeginHorizontal ("box");
			MonoScript mScript = (MonoScript)EditorGUILayout.ObjectField ("MonoBehaviour",script, typeof(MonoScript), false);
			if (mScript != script) {
				script=mScript;
				outputText=string.Empty;
			}
			bool mEnabled = GUI.enabled;
			if (script == null) {
				GUI.enabled=false;
			}
			if(GUILayout.Button("Save",GUILayout.Width(80))){
				string mPath = EditorUtility.SaveFilePanelInProject (
					"Create Action Script",
					script.name+".cs",
					"cs", "");
				if(!string.IsNullOrEmpty(mPath)){
					StreamWriter streamWriter = new System.IO.StreamWriter(mPath, false);
					streamWriter.Write(outputText);
					streamWriter.Close();
					AssetDatabase.Refresh();	
				}
			}
			GUI.enabled = mEnabled;
			GUILayout.EndHorizontal ();
			if (script != null) {
				inputText=script.text;
				if(string.IsNullOrEmpty(outputText)){
					inputText=inputText.Trim();
					string[] lines = inputText.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
					List<string> outputLines= new List<string>();

					for(int i=0;i<lines.Length;i++){
						if(lines[i].StartsWith("public class")){
							outputLines.Add("namespace ICode.Actions{");
							outputLines.Add("\t[Category( \"ScriptConverter\")]");
							outputLines.Add("\t[Tooltip(\"Add some tooltip.\")]");
							outputLines.Add("\t[System.Serializable]");
							outputLines.Add("\t"+lines[i].Replace("MonoBehaviour","StateAction"));
						}else if(lines[i].Contains("void Start")){
							string line=lines[i].Replace("Start","OnEnter");
							if(line.Contains("private")){
								line=line.Replace("private","public override");
							}
							else if(!line.Contains("public") || !line.Contains("private")){
								line="\tpublic override "+line.Trim();
							}
							outputLines.Add("\t"+line);
						}else if(lines[i].Contains("void Update")){
							string line=lines[i].Replace("Update","OnUpdate");
							if(line.Contains("private")){
								line=line.Replace("private","public override");
							}
							else if(!line.Contains("public") || !line.Contains("private")){
								line="\tpublic override "+line.Trim();
							}
							outputLines.Add("\t"+line);
						}else{
							string defaultLine=ReplaceVariable(lines[i]);
							outputLines.Add(lines[i].StartsWith("using")?defaultLine:"\t"+defaultLine);
						}
					}
					outputLines.Add("}");
					outputText=ConvertStringArrayToString(outputLines.ToArray());
				}	
			}
			scroll = GUILayout.BeginScrollView (scroll);
			GUILayout.Label ("Input:");
			GUILayout.BeginVertical ("TextField");
			GUILayout.Label (inputText);
			GUILayout.EndVertical ();

			GUILayout.Label ("Output:");
			GUILayout.BeginVertical ("TextField");
			outputText = EditorGUILayout.TextArea (outputText);
			//GUILayout.Label (outputText);
			GUILayout.EndVertical ();
			GUILayout.EndScrollView ();
		}

		private string ReplaceVariable(string line){
			if (string.IsNullOrEmpty (line) || !line.Contains("public")) {
				return line;
			}
			if (line.Contains ("float")) {
				line= line.Replace("float","FsmFloat");
			}else if (line.Contains ("string")) {
				line= line.Replace("string","FsmString");
			}else if (line.Contains ("Color")) {
				line= line.Replace("Color","FsmColor");
			}else if (line.Contains ("GameObject")) {
				line= line.Replace("GameObject","FsmGameObject");
			}else if (line.Contains ("int")) {
				line= line.Replace("int","FsmInt");
			}else if (line.Contains ("bool")) {
				line= line.Replace("bool","FsmBool");
			}else if (line.Contains ("Vector2")) {
				line= line.Replace("Vector2","FsmVector2");
			}else if (line.Contains ("Vector3")) {
				line= line.Replace("Vector3","FsmVector3");
			}

			if (line.Contains ("=")) {
				string[] lines=line.Split('=');
				line=lines[0].TrimEnd()+";";
			}
			return line;
		}

		private string ConvertStringArrayToString(string[] array)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			foreach (string value in array)
			{
				builder.Append(value);
				builder.Append('\n');
			}
			return builder.ToString();
		}
	}
}