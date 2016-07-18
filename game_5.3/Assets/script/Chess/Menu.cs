using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Menu : MonoBehaviour
{
	
	static float[] tileDimensions = new float[]{2,2};
	float tilesX = 0;
	float tilesY = 0;
	
	string selectCubeId ;
	
//	List<GameObject> changeTiles = new List<GameObject>();
	void TargetSelect(object[] p)
	{	
		selectCubeId = (string)p[0];
		int step = (int)p[1];
		int sx = (int)p[2];
		int sz = (int)p[3];
//		Debug.Log("selectCube:"+selectCubeId);
		foreach(GameObject o in GameObject.FindGameObjectsWithTag("Plane"))
		{
			var script =o.GetComponent<TileControl>();
			if((Mathf.Abs(script.X-sx)+Mathf.Abs(script.Y-sz))<=step)//核心算法
			{
				o.BroadcastMessage("ColorChange", true, SendMessageOptions.RequireReceiver);
			}
			else
			{o.BroadcastMessage("ColorChange", false, SendMessageOptions.RequireReceiver);}
		}
		foreach(GameObject o in GameObject.FindGameObjectsWithTag("Cube"))
			o.BroadcastMessage("ColorChange", selectCubeId, SendMessageOptions.RequireReceiver);
	}
	
	void MoveToTarget(Vector3 p)
	{
				foreach(GameObject o in GameObject.FindGameObjectsWithTag("Cube"))
			o.BroadcastMessage("MoveToTile", p, SendMessageOptions.RequireReceiver);
	}
	
	bool press;
	void OnGUI ()
	{
		if (GUILayout.Button ("6x6")&& !press) {
			press = true;
			tilesX = 6;
			tilesY = 6;
			float worldheight = tileDimensions [0] * tilesX;
			float worldwidth = tileDimensions [1] * tilesY;
			Material mat = (Material)Resources.Load ("TileMaterial2");
			Vector2 size=  new Vector2(1f/tilesX, 1f/tilesY);
			for (int y=0; y<tilesY; y++) {
				for (int x=0; x<tilesX; x++) {
					float posX = x * tileDimensions [0];
					float posY = y * tileDimensions [1];
//					const float ColorDark = 0x80 / 255f;
//					const float ColorLight = 0xAF / 255f;
					GameObject tile = GameObject.CreatePrimitive (PrimitiveType.Plane);
					tile.tag = "Plane";

					Vector2 offset =new Vector2((tilesX-1-x)*size.x,size.y*(tilesY-1-y));
					
					tile.transform.GetComponent<Renderer>().material = mat;
					tile.transform.GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
					tile.transform.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);

//					tile.transform.renderer.material.color = (x + y) % 2 == 0
//						? new Color (ColorDark, ColorDark, ColorDark)
//							: new Color (ColorLight, ColorLight, ColorLight);
					tile.transform.position = new Vector3 (posX + (tileDimensions [0] / 2f), -0.1f, posY + (tileDimensions [1] / 2f));
					Vector3 localScale ;
					tile.transform.localScale = localScale=new Vector3 (tileDimensions [0] / 10f, 0.1f, tileDimensions [1] / 10f);
					tile.AddComponent<TileControl>();
					TileControl script=tile.GetComponent<TileControl>();
					script.X = x;//0-6
					script.Y = y;
					
					script.localScale = localScale;
				}
			}
			
//			for (int y=0; y<tilesY; y++) {
//				for (int x=0; x<tilesX; x++) {
//					float posX = x * tileDimensions [0];
//					float posY = y * tileDimensions [1];
//					const float ColorDark = 0x80 / 255f;
//					const float ColorLight = 0xAF / 255f;
//					GameObject tile = GameObject.CreatePrimitive (PrimitiveType.Plane);
//					tile.transform.renderer.material = mat;
//					
//					tile.transform.renderer.material.color = (x + y) % 2 == 0
//						? new Color (ColorDark, ColorDark, ColorDark)
//							: new Color (ColorLight, ColorLight, ColorLight);
//					tile.transform.position = new Vector3 (posX + (tileDimensions [0] / 2f), -0.1f, posY + (tileDimensions [1] / 2f));
//					tile.transform.localScale = new Vector3 (tileDimensions [0] / 10f, 0.1f, tileDimensions [1] / 10f);
//				}
//			}
			float MaxDimensions = Mathf.Max (worldwidth, worldheight);
			float cameraHeight = Mathf.Sqrt (Mathf.Pow (MaxDimensions, 2) - (MaxDimensions / 4f));
			this.transform.position = new Vector3 (worldwidth / 2f, cameraHeight, worldheight);
			this.transform.LookAt (new Vector3 (worldwidth / 2f, 0, worldheight / 2f));
			
			GameObject theLight = GameObject.Find ("Light");
			theLight.transform.position = this.transform.position;
			theLight.transform.LookAt (new Vector3 (worldwidth / 2f, 0, worldheight / 2f));
			theLight.GetComponent<Light>().range = this.transform.position.y;
			
		}
	}
	
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	public static float[] GetTileDimensions()
	{
		return tileDimensions;
	}
}
