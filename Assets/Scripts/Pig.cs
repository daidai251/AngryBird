using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour {
    public float maxSpend = 10;
    public float mixSpend = 5;
    private SpriteRenderer render;
    public Sprite hurt;

    public GameObject boom;
    public GameObject score;


    public bool isPig;
    // Use this for initialization
    void Start () {
        render = GetComponent<SpriteRenderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > maxSpend)//直接死亡
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > mixSpend && collision.relativeVelocity.magnitude < maxSpend)
        {
            render.sprite = hurt;
        }



    }
    
     void Dead() {

        if (isPig)
        {
            GameManager._intrance.pigs.Remove(this);
        }

        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);//生成特效

        GameObject go=(GameObject) Instantiate(score, transform.position, Quaternion.identity);
        Destroy(go, 1.5f);


    }


}
