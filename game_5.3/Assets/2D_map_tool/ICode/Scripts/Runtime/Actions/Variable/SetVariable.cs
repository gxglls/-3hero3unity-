using UnityEngine;
using System.Collections;

namespace ICode.Actions.Variable{
	[Category(Category.Variable)]
	[Tooltip("Set the value of a variable from other StateMachine.")]
	[System.Serializable]
	public class SetVariable : StateAction {
		[SharedPersistent]
		[Tooltip("GameObject that has a ICodeBehaviour component.")]
		public FsmGameObject gameObject;
		[Tooltip("Group value of ICodeBehaviour to set the variable to.")]
		public FsmInt group;
		[Tooltip("Name of the variable to set.")]
		public FsmString variable;
		[Shared]
		[ParameterType]
		[InspectorLabel("Value")]
		[Tooltip("The value to set.")]
		public FsmVariable _value;
		
		private FsmVariable mVaraible;
		public override void OnEnter ()
		{
			ICodeBehaviour behaviour = gameObject.Value.GetBehaviour (group.Value);
			if (behaviour != null) {
				mVaraible=behaviour.stateMachine.GetVariable(variable.Value);
				if(mVaraible != null){
					mVaraible.SetValue(_value.GetValue());
				}
			}
			Finish ();
		}
	
	}
}