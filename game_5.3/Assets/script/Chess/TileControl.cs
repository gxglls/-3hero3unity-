using UnityEngine;
using System.Collections;

public class TileControl : MonoBehaviour
{
	public int X;//0-6
	public int Y;
	private Color _normalColor;
	bool CanMove;
	void ColorChange(bool canMove)
	{
		this.CanMove = canMove;
		if(this.CanMove)
			GetComponent<Renderer>().material.color = Color.yellow;
		else
		{
			GetComponent<Renderer>().material.color = _normalColor;
		}
	}
	void OnMouseEnter ()
	{
		GetComponent<Renderer>().material.color = Color.blue;	
	}

	void OnMouseDown ()
	{
		if(CanMove)
			GameObject.Find ("Main Camera").SendMessage ("MoveToTarget", transform.position, SendMessageOptions.RequireReceiver);
	}

	void OnMouseExit ()
	{
		if(CanMove)
		{
			GetComponent<Renderer>().material.color = Color.yellow;
		}
		else
		GetComponent<Renderer>().material.color = _normalColor;
	}
	// Use this for initialization
	void Start ()
	{
		_normalColor = GetComponent<Renderer>().material.color;
		if (X <= 1 && Y == 0) {
			GameObject tile = GameObject.CreatePrimitive (PrimitiveType.Cube);
			tile.gameObject.tag = "Cube";
			//tile.transform.parent = transform;
			
		
			tile.transform.position = new  Vector3 (transform.position.x, transform.position.y, transform.position.z);
			//tile.transform.localScale = localScale;
			tile.AddComponent<CubeControl> ();
			CubeControl script = tile.GetComponent<CubeControl>();
			script.X = X;//0-6
			script.Y = Y;
			script.step = Random.Range(3, 5);
		}
	}
	public Vector3 localScale;
	// Update is called once per frame
	void Update ()
	{

	}
}
