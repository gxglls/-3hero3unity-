using UnityEngine;
using System.Collections;

public class example1 : MonoBehaviour
{
	public float scrollSpeed = 0.5F;

	void Update ()
	{        
//		float offset = Time.time * scrollSpeed;     
//		Debug.Log(offset);
//		renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));    
	}
	
	void OnGUI ()
	{
		if (GUILayout.Button ("Change half")) {
			GetComponent<Renderer>().material.SetTextureScale ("_MainTex", new Vector2 (0.5f, 0.5f));
		}
		if (GUILayout.Button ("Change small 9")) {
			GetComponent<Renderer>().material.SetTextureScale ("_MainTex", new Vector2 (1f / 9f, 1f / 9f));
		}
		if (GUILayout.Button ("offsest normal")) {
			GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2 (0f, 0f));
		}		
		if (GUILayout.Button ("offsest normal half")) {
			GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2 (0.5f, .5f));
		}			
		if (GUILayout.Button ("Change normal")) {
			GetComponent<Renderer>().material.SetTextureScale ("_MainTex", new Vector2 (1f, 1f));
		}
	}
}
