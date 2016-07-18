using UnityEngine;
using System.Collections;

public class SrcManager : MonoBehaviour {
    public static float wooden;
    public static float jewel;
    public static float stone;
    public static float sulphur;

	// Use this for initialization
	void Start () {
        wooden = 10;
        jewel = 10;
        stone = 10;
        sulphur = 10;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnSrcPickup(string tag) {
    UILabel[] uil=GetComponentsInChildren<UILabel>();
        switch (tag.Trim()) {
            case "wooden":
		OnWoodenChanged(uil[0]);
            break;
            case "jewel":
		OnJewelChanged(uil[2]);
            break;
            case "stone":
		OnStoneChanged(uil[4]);
            break;
            case "sulphur": OnSulphurChanged(uil[6]); 
			break;
        }
    }
    public void OnWoodenChanged(UILabel uil) {
        Debug.Log("login");
	uil.text=(float.Parse(uil.text)+1.0f).ToString();
    }
    public void OnJewelChanged(UILabel uil) {
        Debug.Log("login");
	uil.text=(float.Parse(uil.text)+1.0f).ToString();
    }
    public void OnStoneChanged(UILabel uil) {
        Debug.Log("login");
	uil.text=(float.Parse(uil.text)+1.0f).ToString();
    }
    public void OnSulphurChanged(UILabel uil) {
        Debug.Log("login");
	uil.text=(float.Parse(uil.text)+1.0f).ToString();
    }
}
