using UnityEngine;
using System.Collections;

namespace ICode.Actions.Array{
	[System.Serializable]
	public abstract class ArrayAction : StateAction {
		[Shared]
		[Tooltip("GameObject to use.")]
		public FsmArray array;
	}
}