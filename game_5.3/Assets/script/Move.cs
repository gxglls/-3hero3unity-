using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {
    //public CharacterController con;
    //public Vector3 pos;
    //public Vector2 nextPos;
    public Animator animator;
    //public float moveSmooth = 2;
    //public Rigidbody2D rigidbody;
    //public CharacterController con;
    private bool turnFlag=true;
	// Use this for initialization
	public float stepSize=2;
	private Vector3 targetPos;
	private RaycastHit2D hit;  //射线检测
	private Collider2D col;
	private  bool isEnter=false;

	//-------------数据部分定义开始---------------//
	//public Dictionary<string,int> army=new Dictionary<string,int>();
	public List<string> armyName = new List<string>();
	public List<int> armyNum = new List<int>();
	//-------------数据部分结束------------------//
	

	void Start () {
       // pos = transform.position;
        animator = GetComponent<Animator>();
		targetPos = transform.position;
		DontDestroyOnLoad(this.gameObject);
		col = GetComponent<Collider2D>();
		//兵的信息
		armyName.Add("archer");
		armyName.Add("infantry");
		armyNum.Add(10);
		armyNum.Add(10);
        //rigidbody = GetComponent<Rigidbody2D>();
        //con = GetComponent<CharacterController>();	
	}

    //void FixedUpdate() {
		/*鼠标控制
        //Vector2 nextPos =Vector2.ClampMagnitude(pos -new Vector2(transform.position.x,transform.position.y),0.2f);
        nextPos = pos - transform.position;
    //rigidbody.velocity
        //con.Move(nextPos*Time.fixedDeltaTime);
        //transform.Translate(nextPos * Time.deltaTime * moveSmooth);
        //rigidbody.MovePosition(rigidbody.position+nextPos*Time.deltaTime);
        rigidbody.MovePosition(Vector2.Lerp(transform.position, pos, Time.deltaTime));
        if (nextPos.magnitude <= 0.3)
        {
            animator.SetBool("move", false);
        }
		 * */


       // }
	
	// Update is called once per frame



    void Update()
    {
		/*鼠标控制
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(Input.mousePosition);
            //pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //Debug.Log("ScreenToViewportPoint:"+pos);
            animator.SetBool("move", true);
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (pos.x > transform.position.x && turnFlag==false) {
                turnFlag = true;
                Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.localScale = temp;
            } 
            if (pos.x < transform.position.x && turnFlag == true)
            {
                turnFlag=false;
                Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.localScale = temp;
            }
            //Debug.Log("ScreenToWorldPoint:"+ pos);
        }*/
		if (Input.GetKeyDown(KeyCode.D)) {

			//射线碰撞检测
			col.enabled = false;
			hit = Physics2D.Linecast(transform.position, new Vector3(transform.position.x + stepSize, transform.position.y, 0));
			Debug.DrawLine(transform.position, targetPos);
			col.enabled = true;
			targetPos = new Vector3(transform.position.x + stepSize, transform.position.y, 0);
			
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			col.enabled = false;
			hit = Physics2D.Linecast(transform.position, new Vector3(transform.position.x - stepSize, transform.position.y, 0));
			Debug.DrawLine(transform.position, targetPos);
			col.enabled = true;
			targetPos = new Vector3(transform.position.x - stepSize, transform.position.y, 0);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{

			//射线碰撞检测
			col.enabled = false;
			hit = Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y + stepSize, 0));
			Debug.DrawLine(transform.position, targetPos);
			col.enabled = true;
			targetPos = new Vector3(transform.position.x, transform.position.y + stepSize, 0);
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			col.enabled = false;
			hit = Physics2D.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - stepSize, 0));
			Debug.DrawLine(transform.position, targetPos);
			col.enabled = true;
			targetPos = new Vector3(transform.position.x, transform.position.y - stepSize, 0);
		}
		moveTo(targetPos);
    }

	void moveTo(Vector3 targetPos) {

	    //说明LoadLevel后，脚本并没有完全死掉？？



		if (hit.collider!=null) {

			switch (hit.collider.tag)
			{
				case "city": isEnter = true; targetPos = transform.position; Application.LoadLevel("city"); break;
				case "enemy": 
					isEnter = true; 
					targetPos = transform.position;
					for (int i = 0; i < armyName.Count; i++)
					{
						Data.armyName.Add(armyName[i]);
						Data.armyNum.Add(armyNum[i]);
					}
					Application.LoadLevel("battle"); 
				break;
			case "jewel":
				break;
			case "wooden":
				break;
			}
			//Debug.Log(hit);
		}

		if (hit.collider == null&&isEnter==false||hit.collider.tag=="jewel"||hit.collider.tag=="wooden") {
			//方向检测
			if (targetPos.x > transform.position.x && turnFlag == false)
			{
				turnFlag = true;
				Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = temp;
			}
			if (targetPos.x < transform.position.x && turnFlag == true)
			{
				turnFlag = false;
				Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
				transform.localScale = temp;
			}

			animator.SetBool("move", true);
			transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
			if (transform.position == targetPos)
			{
				animator.SetBool("move", false);
			}
		}

	}

	void OnLevelWasLoaded(int level)
	{
		if (level == 1) {
			Destroy(GameObject.FindGameObjectsWithTag("Player")[1]);
			isEnter = false;		//为了让最后一步不走进去，两个参数来卡着
			targetPos = transform.position;
		}
	}
    //void OnTriggerEnter() {
    //    nextPos = transform.position;
    //}
}
