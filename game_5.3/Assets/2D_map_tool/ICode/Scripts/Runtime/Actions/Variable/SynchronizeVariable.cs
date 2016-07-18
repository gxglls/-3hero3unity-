using UnityEngine;
using System.Collections;

namespace ICode.Actions.Variable{
	[Category(Category.Variable)]
	[Tooltip("Similiar to GetVariable, but the variable will be still updated when you are not calling the action.")]
	[System.Serializable]
	public class SynchronizeVariable : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject that has a ICodeBehaviour component.")]
		public FsmGameObject gameObject;
		[Tooltip("Group value of ICodeBehaviour to get the variable from.")]
		public FsmInt group;
		[Tooltip("Name of the variable to get.")]
		public FsmString variable;
		[Shared]
		[ParameterType]
		[Tooltip("The value to set.")]
		public FsmVariable store;
		
		private FsmVariable mVaraible;
		public override void OnEnter ()
		{
			ICodeBehaviour behaviour = gameObject.Value.GetBehaviour (group.Value);
			if (behaviour != null) {
				mVaraible=behaviour.stateMachine.GetVariable(variable.Value);
				if(mVaraible != null){
					mVaraible.onVariableChange.AddListener(DoSync);
				}
			}
		
			Finish ();
		}
		private void DoSync(object value){
			store.SetValue (value);
		}
	}
}