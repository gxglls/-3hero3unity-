using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour {
    public SpriteRenderer spr;
    public AudioClip audioClip;
    public GameObject UIRoot;
    public SrcManager srcManager;
	// Use this for initialization
	void Start () {
        spr = GetComponent<SpriteRenderer>();
        UIRoot = GameObject.FindGameObjectWithTag("UIRoot");
        srcManager = UIRoot.GetComponent<SrcManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
        AudioSource.PlayClipAtPoint(audioClip, transform.position,1.0f);
        srcManager.OnSrcPickup(this.tag);
        Debug.Log(this.tag);
        InvokeRepeating("disappear", 0, 0.18f);
        Destroy(gameObject, 1);
    }

    public void disappear() {
        float a = spr.color.a - 0.1f;
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, a);
    }
}
