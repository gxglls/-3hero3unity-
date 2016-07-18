using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class AnimatorIKProxy : MonoBehaviour {
		public event Action<int> onAnimatorIK;
		private void OnAnimatorIK(int layer)
		{
			if( onAnimatorIK != null )
			{
				onAnimatorIK(layer);
			}
		}
	}
}