using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ICode{
	[AddComponentMenu("ICode/OverrideVariables")]
	public class OverrideVariables : MonoBehaviour {
		public ICodeBehaviour behaviour;
		public List<SerializedVariable> setVariables;

		private void Start(){
			if (behaviour.stateMachine != null) {
				if(!behaviour.stateMachine.IsInitialized){
					bool isEnabled=behaviour.enabled;
					behaviour.EnableStateMachine();
					behaviour.enabled=isEnabled;
				}
				for(int i=0;i< setVariables.Count;i++){
					FsmVariable variable=behaviour.stateMachine.GetVariable(setVariables[i].name);
					if(variable != null){
						variable.SetValue(setVariables[i].GetValue());
					}
				}
			}
		}

	}
}