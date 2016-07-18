using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ICode{
	[System.Serializable]
	public class GlobalVariables : ScriptableObject {
		public const string assetName = "GlobalVariables";

		[SerializeField]
		private FsmVariable[] variables = new FsmVariable[0];
		public FsmVariable[] Variables{
			get{
				return variables;
			}
			set{
				variables=value;
			}
		}

		private static GlobalVariables globalVariables;

		public static GlobalVariables Load(){
			return GlobalVariables.Load (GlobalVariables.assetName);	
		}

		public static GlobalVariables Load(string name){
			if (globalVariables == null) {
				globalVariables=Resources.Load<GlobalVariables>(name);
			}
			return globalVariables;
		}

		public static FsmVariable GetVariable(string name){
			GlobalVariables globalVariables = Load (GlobalVariables.assetName);
			if (globalVariables == null) {
				return null;			
			}
			for (int i=0; i< globalVariables.Variables.Length; i++) {
				FsmVariable variable=globalVariables.Variables[i];	
				if(variable.Name == name){
					return variable;
				}
			}
			return null;
		}

		public static bool SetVariable(string name, object value){
			FsmVariable variable = GlobalVariables.GetVariable (name);
			if (variable != null && variable.VariableType == value.GetType()) {
				variable.SetValue(value);
				return true;
			}
			return false;
		}
		
		public static FsmVariable[] GetVariables(){
			GlobalVariables globalVariables = Load (GlobalVariables.assetName);
			if (globalVariables == null) {
				return new FsmVariable[0];		
			}
			return globalVariables.Variables;
		}
		
		public static string[] GetVariableNames(params Type[] types){
			FsmVariable[] variables = GlobalVariables.GetVariables ();
			List<string> names = new List<string> ();

			foreach (FsmVariable variable in variables) {
				if(types.Length==0){
					names.Add(variable.Name);
				}else{
					foreach(Type type in types){
						if(variable.GetType()==type){
							names.Add(variable.Name);
						}
					}	
				}
			}
			return names.ToArray();
		}

	}
}