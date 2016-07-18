using UnityEngine;
using System.Collections;

public class city : MonoBehaviour {
	public bool colliderFlag=true;
    void OnTriggerEnter2D() {
		if (colliderFlag) {
			Debug.Log(1);
			Application.LoadLevel(2);
			colliderFlag = false;
		}

    }

	void OnTriggerExit() {
		colliderFlag = true;
	}
}
