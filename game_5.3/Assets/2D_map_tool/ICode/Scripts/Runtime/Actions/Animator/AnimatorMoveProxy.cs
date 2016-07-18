using UnityEngine;
using System.Collections;
using System;

namespace ICode{
	public class AnimatorMoveProxy : MonoBehaviour {
		public event Action onAnimatorMove;
		private void OnAnimatorMove()
		{
			if( onAnimatorMove != null )
			{
				onAnimatorMove();
			}
		}
	}
}