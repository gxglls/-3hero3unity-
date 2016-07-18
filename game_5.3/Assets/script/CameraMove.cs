using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
    public float speed=10;
    private float pos = 0;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();        
        }
        //Debug.Log(Screen.height + "x" + Screen.width);
        if (Input.mousePosition.x < 0.5) {
            if (transform.position.x < -5)
            {
                transform.position = transform.position;
            }
            else {
                pos = transform.position.x - speed * Time.deltaTime;
                transform.position = new Vector3(pos, transform.position.y, -10);
            }

        }
        if (Input.mousePosition.x >Screen.width-0.5)
        {
            if (transform.position.x > 1)
            {
                transform.position = transform.position;
            }
            else {
                pos = transform.position.x + speed * Time.deltaTime;
                transform.position = new Vector3(pos, transform.position.y, -10);
            }


        } 
        if (Input.mousePosition.y < 0.5)
        {
            if (transform.position.y <-10)
            {
                transform.position = transform.position;
            }
            else
            {
                pos = transform.position.y - speed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, pos, -10);
            }
        } 
        if (Input.mousePosition.y > Screen.height-0.5)
        {
            if (transform.position.y > 10)
            {
                transform.position = transform.position;
            }
            else
            {
                pos = transform.position.y + speed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, pos, -10);
            }
        }
        

    }
}
