using UnityEngine;
using System.Collections;

namespace ICode{
	public class SetGlobalGameObject : MonoBehaviour {
		public string variableName;
		public GameObject target;

		private void Start(){
			if (target == null) {
				target=gameObject;		
			}
			GlobalVariables.SetVariable (variableName, target);
		}
	}
}