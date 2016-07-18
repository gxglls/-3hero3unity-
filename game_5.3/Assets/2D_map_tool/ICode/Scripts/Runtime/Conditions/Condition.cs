using UnityEngine;
using System.Collections;

namespace ICode.Conditions{
	[System.Serializable]
	public class Condition : ExecutableNode {
		public virtual bool Validate(){
			return true;
		}
	}
}