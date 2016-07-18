using UnityEngine;
using System.Collections;

public class a : MonoBehaviour {
    Vector3 pos;
	// Use this for initialization
	void Start () {
	  pos = new Vector3(transform.position.x + 13, transform.position.y, 0);
        

	}
	
	// Update is called once per frame
	void Update () {
      transform.position=Vector3.MoveTowards(transform.position, pos, 0.1f);


	}
}
