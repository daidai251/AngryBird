using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
    private Vector3 inpos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate(Vector3.forward * Time.deltaTime);//默认是局部
        Debug.Log("transform" + transform.position);
        //inpos = transform.InverseTransformPoint(Vector3.forward);//不规范
        //inpos = transform.InverseTransformDirection(Vector3.forward);//把局部的Z 改成全局的Z
        //inpos = transform.TransformPoint(Vector3.forward);
        Debug.Log("inpos" + inpos.z);
        transform.Translate(inpos*Time.deltaTime);

    }
}
