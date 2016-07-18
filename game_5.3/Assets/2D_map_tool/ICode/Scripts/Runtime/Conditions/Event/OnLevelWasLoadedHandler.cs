using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class OnLevelWasLoadedHandler : MonoBehaviour {
		public Action<int> onLevelWasLoaded;
		
		private void OnLevelWasLoaded(int level) {
			if (onLevelWasLoaded != null) {
				onLevelWasLoaded(level);			
			}
		}
	}
}