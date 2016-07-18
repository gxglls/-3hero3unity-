using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class OnGUIProxy : MonoBehaviour {
		public event Action onGUI;
		private void OnGUI()
		{
			if( onGUI != null )
			{
				onGUI();
			}
		}
	}
}