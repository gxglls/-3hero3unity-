using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitBoard : MonoBehaviour {
    public GameObject board;
	//public Tile boardScript;
	//public GameObject test;
	//public chess testScript;
    public static float startXpoint = -7.6f;
    public static float startYpoint = -3.5f;
	public static float offset = 1.1f;  //瓷砖偏移量
    public static List<Vector3> position=new List<Vector3>();
	public List<GameObject> allArmy = new List<GameObject>();

	// Use this for initialization
	void Start () {
		//Debug.Log(GameObject.Find("/prefabs/archer"));
		//boardScript = board.GetComponent<Tile>();
		//testScript = test.GetComponent<chess>();
        for (int i = 0; i < 6; i++) {
            for (int j = 0; j < 15; j++) {
				//先铺一层board
                position.Add(new Vector3(startXpoint + j*offset, startYpoint + i*offset, 0));
				GameObject obj=Instantiate(board, position[j+15*i], Quaternion.identity) as GameObject;
				obj.tag = "tile";
				obj.GetComponent<MyTile>().tileID = new int[2] { i, j };
				//原写法，大坑啊，作用的对象要搞明白
				//Instantiate(board, position[j + 15 * i], Quaternion.identity);
				//board.tag = "tile";
				//board.GetComponent<Tile>().tileID = new int[2] { i, j };

				//Debug.Log(board.GetComponent<Tile>().tileID[0]+","+board.GetComponent<Tile>().tileID[1]);
            }
        }

		//for (int i = 0; i < position.Count; i++)
		//{

		//	boardScript.x = position[i].x;
		//	boardScript.y = position[i].y;
		//	board.GetComponent<Tile>().tileID = new int[2] { (int)((position[i].y - startYpoint) / offset), (int)((position[i].x - startXpoint) / offset) };

		//}

		//GameObject temp=Instantiate(test, position[3], Quaternion.identity) as GameObject;
		//int positionIndex = 3;
		//int chessID_x, chessID_y;
		//positionToID(positionIndex, out chessID_x,out chessID_y);   //关于out的使用，引用传递
		//temp.GetComponent<chess>().chessID = new int[2] { chessID_x, chessID_y };
		instancePlayerArmy();
	}

	public static void positionToID(int positionIndex, out int x, out int y){		//坐标转成id
		x = (int)((position[positionIndex].y - startYpoint) / offset);
		y = (int)((position[positionIndex].x - startXpoint) / offset);
	}

	public static Vector3 IDToPosition(int[] ID) { 
		return(new Vector3(ID[1]*offset+startXpoint,ID[0]*offset+startYpoint,0));
	}

	public void instancePlayerArmy() {

		for (int i = 0; i < Data.armyName.Count; i++) {
			Debug.Log(222);
			for(int j=0;j<allArmy.Count;j++){
				Debug.Log(333);
				if(Data.armyName[i].ToString()==allArmy[j].tag){
				Debug.Log(444);
					int index = (j + 2) * 15;
					GameObject temp = Instantiate(allArmy[j], position[index], Quaternion.identity) as GameObject;
				//position.RemoveAt (positionIndex * 15);
				int chessID_x, chessID_y;
					positionToID(index, out chessID_x, out chessID_y);   //关于out的使用，引用传递
				temp.AddComponent<chess>();
				temp.GetComponent<chess>().chessID = new int[2] { chessID_x, chessID_y };
					Debug.Log (chessID_x + "," + chessID_y);
			}

			}

		}

	}

	void onlevelwasloaded(int level) {

	}
}
