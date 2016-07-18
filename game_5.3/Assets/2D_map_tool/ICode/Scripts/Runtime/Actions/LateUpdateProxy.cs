using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class LateUpdateProxy : MonoBehaviour {
		public event Action onLateUpdate;
		private void LateUpdate()
		{
			if( onLateUpdate != null )
			{
				onLateUpdate();
			}
		}
	}
}