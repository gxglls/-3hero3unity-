using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns the value of the virtual axis identified by axisName.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetAxis.html")]
	[System.Serializable]
	public class GetAxis : StateAction {
		[Tooltip("Virtual axis name.")]
		public FsmString axisName;
		[DefaultValue(1.0f)]
		[Tooltip("Multiply the value.")]
		public FsmFloat multiply;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetAxis (axisName.Value)*multiply.Value;	
		}
	}
}