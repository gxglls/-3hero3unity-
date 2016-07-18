using UnityEngine;
using System.Collections;

namespace ICode.Actions.UnityPlayerPrefs{
	[System.Serializable]
	public abstract class PlayerPrefsAction : StateAction {
		[Tooltip("Key to use.")]
		public FsmString key;
	}
}