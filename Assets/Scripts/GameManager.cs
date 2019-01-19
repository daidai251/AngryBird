using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<Bird> birds;
    public List<Pig> pigs;

    //private Transform initPos;//初始位置
    private Vector3 initPos;//初始位置

    // Use this for initialization

    public static GameManager _intrance;
	void Start () {
        _intrance = this;
        if (birds.Count > 0)
        {
            initPos = birds[0].transform.position;
        }
        initialized();

    }
	
    public void initialized() {
        for(int i = 0; i < birds.Count; i++)
        {
            if(i==0)//第一个，让其存在
            {
                //birds[i].transform.position = initPos.position;
                birds[i].transform.position = initPos;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }

        }

    }

    //游戏逻辑的判定
    public void NextBird() {
        if (pigs.Count > 0) {
            if (birds.Count >0)
            {
                //下一只
                initialized();


            }
            else
            {
                //输了
            }



        }
        else
        {
            //赢了
        }


    }


}
