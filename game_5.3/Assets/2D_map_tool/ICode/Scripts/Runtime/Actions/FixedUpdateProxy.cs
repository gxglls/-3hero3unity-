using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class FixedUpdateProxy : MonoBehaviour {
		public event Action onFixedUpdate;
		private void FixedUpdate()
		{
			if( onFixedUpdate != null )
			{
				onFixedUpdate();
			}
		}
	}
}