using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityVector3{
	[Category(Category.Vector3)] 
	[Tooltip("Linearly interpolates between two vectors.")]
	[HelpUrl("http://docs.unity3d.com/ScriptReference/Vector3.Lerp.html")]
	[System.Serializable]
	public class Lerp : StateAction {
		public FsmVector3 from;
		public FsmVector3 to;
		public FsmFloat smooth;
		[Shared]
		[Tooltip("Store the result.")]
		public FsmVector3 store;

		public override void OnUpdate ()
		{
			store.Value = Vector3.Lerp (from.Value, to.Value, Time.deltaTime * smooth.Value);
		}
	}
}