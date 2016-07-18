using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityInput{
	[Category(Category.Input)]
	[Tooltip("Returns the value of the virtual axis identified by axisName with no smoothing filtering applied.")]
	[HelpUrl("https://docs.unity3d.com/Documentation/ScriptReference/Input.GetAxisRaw.html")]
	[System.Serializable]
	public class GetAxisRaw : StateAction {
		[Tooltip("Virtual axis name.")]
		public FsmString axisName;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmFloat store;

		public override void OnUpdate ()
		{
			store.Value = Input.GetAxisRaw (axisName.Value);	
		}
	}
}