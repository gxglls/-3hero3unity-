using UnityEngine;
using System.Collections;

public class chess : MonoBehaviour {
	public int step;
	public int[] chessID;
	public chess _instance;
	public bool moveFlag=false;
	//public Vector3 targetPos;
	//public bool isShadow = true;  //是否可以显示阴影
	public int[] targetTileID;
	public Animator anim;
	public float moveSpeed;
	public bool turnFlag = true;
	// Use this for initialization
	void Start () {
		//chessID = new int[2];
		moveSpeed = 0.05f;
		step = 4;
		_instance = this;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (moveFlag) {
			MoveToTarget(targetTileID);

		}
	}

	void OnMouseDown() {
		tileShadowControl(true);		
	}

	void MoveToTarget(int[] tileID) {
		tileShadowControl(false);
		anim.SetBool("move", true);
		if (Mathf.Abs(tileID[0] - chessID[0]) >= Mathf.Abs(tileID[1] - chessID[1]))
		{
			//朝向判断
			if (tileID[1] > chessID[1] && turnFlag == false)
			{
				turnFlag = true;
				Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = temp;
			}
			if (tileID[1] < chessID[1] && turnFlag == true)
			{
				turnFlag = false;
				Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = temp;
			}

			//移动
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(InitBoard.IDToPosition(tileID).x, transform.position.y, 0), moveSpeed);
			if (transform.position.x == InitBoard.IDToPosition(tileID).x)
			{
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, InitBoard.IDToPosition(tileID).y, 0), moveSpeed);
				chessID = tileID;
				if (transform.position == InitBoard.IDToPosition(tileID)) {
					tileShadowControl(true);
					anim.SetBool("move", false);
				}

			}
		}
		else {
			//朝向判断
			if (tileID[1] > chessID[1] && turnFlag == false)
			{
				turnFlag = true;
				Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = temp;
			}
			if (tileID[1] < chessID[1] && turnFlag == true)
			{
				turnFlag = false;
				Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = temp;
			}

			//移动
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, InitBoard.IDToPosition(tileID).y, 0), moveSpeed);
			if (transform.position.y == InitBoard.IDToPosition(tileID).y)
			{
				transform.position = Vector3.MoveTowards(transform.position, new Vector3(InitBoard.IDToPosition(tileID).x, transform.position.y, 0), moveSpeed);
				chessID = tileID;
				if (transform.position == InitBoard.IDToPosition(tileID))
				{
					tileShadowControl(true);
					anim.SetBool("move", false);
				}
			}
		}


	}

	public void tileShadowControl(bool isSelectItem) {
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("tile"))
			{
				MyTile objScript = obj.GetComponent<MyTile>();
				if (Mathf.Abs(objScript.tileID[0] - chessID[0]) + Mathf.Abs(objScript.tileID[1] - chessID[1]) < step)
				{
					obj.GetComponent<MyTile>().itemInstance = _instance;
					obj.GetComponent<MyTile>().isSelectItem = isSelectItem;
					obj.SendMessage("showShadow", SendMessageOptions.RequireReceiver);
				}
			}
		}

}
