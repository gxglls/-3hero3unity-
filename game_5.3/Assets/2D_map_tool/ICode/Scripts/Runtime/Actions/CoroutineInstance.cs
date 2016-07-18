using UnityEngine;
using System.Collections;

namespace ICode{
	public class CoroutineInstance : MonoBehaviour
	{
		public Coroutine ProcessWork (IEnumerator routine)
		{
			return StartCoroutine (DestroyWhenComplete (routine));
		}
		
		public IEnumerator DestroyWhenComplete (IEnumerator routine)
		{
			yield return StartCoroutine(routine);
			Destroy (gameObject);
		}
	}
}