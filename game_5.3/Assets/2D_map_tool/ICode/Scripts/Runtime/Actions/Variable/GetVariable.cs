using UnityEngine;
using System.Collections;

namespace ICode.Actions.Variable{
	[Category(Category.Variable)]
	[Tooltip("Gets the value of a variable from other StateMachine.")]
	[System.Serializable]
	public class GetVariable : StateAction {
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
		[Tooltip("Stop to update the variable on exit of the state.")]
		public FsmBool stopOnExit;
		
		private FsmVariable mVaraible;
		public override void OnEnter ()
		{
			ICodeBehaviour behaviour = gameObject.Value.GetBehaviour (group.Value);
			if (behaviour != null) {
				mVaraible=behaviour.stateMachine.GetVariable(variable.Value);
				if(mVaraible != null){
					mVaraible.onVariableChange.AddListener(DoGet);
					store.SetValue(mVaraible.GetValue());
				}
			}
			Finish ();
		}

		public override void OnExit ()
		{
			if (stopOnExit.Value && mVaraible != null) {
				mVaraible.onVariableChange.RemoveListener(DoGet);
			}
		}

		private void DoGet(object value){
			store.SetValue(value);
		}
	}
}