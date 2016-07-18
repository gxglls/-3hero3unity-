using UnityEngine;
using System.Collections;

namespace ICode.Actions{
	[System.Serializable]
	public class StateAction : ExecutableNode {
		private bool isFinished;
		public bool IsFinished
		{
			get{
				return this.isFinished;
			}
		}

		public void Finish()
		{
			this.isFinished = true;
		}

		public void Reset(){
			this.isFinished = false;
			this.IsEntered = false;
		}
		
		public virtual void OnUpdate(){}
	}
}