using UnityEngine;
using System.Collections;

public class CubeControl : MonoBehaviour
{

    private Vector3 destinationPosition;
    private Transform myTransform;
    private float destinationDistance;
    private float moveSpeed;	
    public int step;
	bool Moving2;
	Vector3 destinationPosition2;
    string cubeId;
    bool canMove;
    public int X;
    public int Y;

	void MoveToTile (Vector3 p)
	{
		if (canMove) {
			if (myTransform.position.x == p.x|| myTransform.position.z == p.z) {
				destinationPosition = new Vector3(p.x, myTransform.position.y, p.z);
			}
			else
			{
				Moving2= true;
				destinationPosition = new Vector3(myTransform.position.x, myTransform.position.y, p.z);
				destinationPosition2 = p;
			}
		}
	}

	
	void OnMouseDown ()
	{
//		Debug.Log("old X="+X+",Y="+Y+"step="+step);
		X = (int)Mathf.Floor(myTransform.position.x / Menu.GetTileDimensions()[0]);//传递单位 cube的坐标
		Y = (int)Mathf.Floor(myTransform.position.z / Menu.GetTileDimensions()[1]);
        Debug.Log(X+","+Y);
//		Debug.Log("X="+X+",Y="+Y+"step="+step);
		GameObject.Find ("Main Camera").SendMessage ("TargetSelect", new object[]{cubeId, step, X, Y}, SendMessageOptions.RequireReceiver);
	}
	
	void ColorChange (string p)
	{
		if (cubeId == p) {
			canMove = true;

			GetComponent<Renderer>().material.color = Color.red;
		} else {
			canMove =false;
			
			GetComponent<Renderer>().material.color = Color.white;
		}
	}
	// Use this for initialization
	void Start ()
	{	
		myTransform = transform;
		destinationPosition = myTransform.position;
		cubeId =X+","+Y;
		gameObject.tag = "Cube";
        
	}


	// Update is called once per frame
	void Update ()
	{
		destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
		if (destinationDistance < .5f) {		// To prevent shaking behavior when near destination
			moveSpeed = 0;
			myTransform.position = destinationPosition;
			if(Moving2)
			{
		
				Moving2 = false;
				MoveToTile(destinationPosition2);
			}
		} else if (destinationDistance > .5f) {			// To Reset Speed to default
			moveSpeed = 3;
		}	
		if (destinationDistance > .5f)
		{
//			myTransform.rotation=Quaternion.LookRotation(destinationPosition - transform.position);
			myTransform.position = Vector3.MoveTowards (myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
		}
	}
}
