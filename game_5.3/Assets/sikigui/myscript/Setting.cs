using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour {
    public float vol = 1;
    public enum dif
    {
        esay,
        normal,
        difficulty
    };
    public dif difficulty = dif.normal;
    public bool fullScreen=false;
	// Use this for initialization
	void Start () {
        Debug.Log(dif.difficulty);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void OnSettingDown() {
        Application.LoadLevel("setting");
    }
    public void OnStartDown() {
        Application.LoadLevel("game");
    }
    public void OnReTurnDown() {
        Application.LoadLevel("start");
    }
    public void OnVolChange() {
       // Debug.Log("vol");
        vol = UIProgressBar.current.value;
    }
    public void OnDifChange()
    {
        //Debug.Log("dif");
        switch (UIPopupList.current.value.Trim()) {
            case "简单": difficulty = dif.esay; break;
            case "一般": difficulty = dif.normal; break;
            case "困难": difficulty = dif.difficulty; break;
        }
    }
    public void OnScreenChanger()
    {
        //Debug.Log("Screen");
        fullScreen = UIToggle.current.value;
    }
}
