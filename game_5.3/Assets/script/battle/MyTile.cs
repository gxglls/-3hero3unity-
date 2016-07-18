using UnityEngine;
using System.Collections;

public class MyTile : MonoBehaviour {
	public float x;
	public float y;
	public int[] tileID;
	public SpriteRenderer spriteRenderer;
	public Sprite board;
	public Sprite move_area;
	public Sprite move_point;
	public bool isSelectItem = true;  //是否选择了单位
	//public bool isMovePoint = false;	//是否是可移动的点
	public chess itemInstance;		//当前被选中的对象
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void showShadow() {
		if (isSelectItem)
		{
			spriteRenderer.sprite = move_area;
		}
		else {
			spriteRenderer.sprite = board;
		}
	}

	void OnMouseOver() {
		if (isSelectItem) {
			spriteRenderer.sprite = move_point;
		}

	}

	void OnMouseExit() {
		if (isSelectItem) {
			spriteRenderer.sprite = move_area;
		}
	}

	void OnMouseDown() {
		if (isSelectItem == true) {
			//itemInstance.tileShadowControl(false);
			itemInstance.targetTileID = this.tileID;
			itemInstance.moveFlag = true;
			//itemInstance.targetPos = InitBoard.IDToPosition(this.tileID);

		}

	}
}
