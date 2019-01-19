using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class Bird : MonoBehaviour {

	private bool isKeyDown=false;
   
    public float maxDis = 1.5f;
    private Rigidbody2D rg;
    [HideInInspector]
    public SpringJoint2D sp;

    public LineRenderer right;
    public Transform rightPos;
    public LineRenderer left;
    public Transform leftPos;

    public GameObject boom;
    private TestMyTrail myTrail;
    

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpringJoint2D>();
        myTrail = GetComponent<TestMyTrail>();
    }

    private void OnMouseDown(){
		isKeyDown = true;
        rg.isKinematic = true;

    }
	private void OnMouseUp(){
		isKeyDown = false;
 
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);
        
        //禁用划线
        right.enabled = false;
        left.enabled = false;


	}
	private void  Update(){
		if (isKeyDown) {
			transform.position = Camera.main.ScreenToWorldPoint( Input.mousePosition);
			//Debug.Log ("playe" + transform.position);
			//Debug.Log ("Camer:" + Input.mousePosition);
            //transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0); //鼠标位置是屏幕像素值得位置，所以数值比较大
            //transform.position += new Vector3(0, 0, 10);//因为Z 是-10 导致看不到了，所以+10弄到前面来 为0
            transform.position += new Vector3(0,0, -Camera.main.transform.position.z);
            if (Vector3.Distance(rightPos.position, transform.position) > maxDis)
            {
                //单位向量
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
                //Debug.Log("tranform"+transform.position);
            }

            DrawnLine();
        }
       
	}

    public void Fly() {
        Invoke("Next", 3f);
        sp.enabled = false;
        myTrail.startTrails();
    }

    public void DrawnLine() {
        right.enabled = true;
        left.enabled = true;

        Debug.Log(right.transform.position);
        right.SetPosition(0, rightPos.transform.position);
        right.SetPosition(1, transform.position);

        left.SetPosition(0, leftPos.transform.position);
        left.SetPosition(1, transform.position);



    }

    //下一只鸟的飞出
    public void Next() {
      
        Debug.Log("bird中的this是什么" + this);//play
        GameManager._intrance.birds.Remove(this);
        Debug.Log("bird中gameObject:" + gameObject);
        Destroy(gameObject);

        Instantiate(boom, transform.position, Quaternion.identity);

        GameManager._intrance.NextBird();
    }

    private void OnCollisionEnter2D(Collider2D collider2D)
    {

        //myTrail.ClearTrails();
    }

}
