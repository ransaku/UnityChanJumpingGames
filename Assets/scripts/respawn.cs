using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour {
    public static int levelN = 0;
    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        //记录初始位置
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
    }

    void nextLevel()
    {
        levelN++;

        if (levelN > 1) {
            levelN = 0;
        }

        //Application.LoadLevel(levelN);

        SceneManager.LoadScene(levelN);
       
    }

    private void OnTriggerEnter(Collider coll)
    {
        //若摔死则返回初始位置
        if (coll.tag == "death")
        {

            gameObject.transform.position = startPos;
            gameObject.transform.rotation = startRot;

            //播放懊恼动作
            gameObject.GetComponent<Animator>().Play("LOSE00", -1, 0f);

            //重置动作位移和角度
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);

        }
        else if (coll.tag == "checkpoint")
        {
            //记录checkpoint
            startPos = coll.gameObject.transform.position;
            startRot = coll.gameObject.transform.rotation;
            //到达后销毁checkpoint模型
            Destroy(coll.gameObject);

        }
        else if (coll.tag == "goal") {
            //到达终点销毁goalteleport模型
            Destroy(coll.gameObject);
            //播放胜利动画
            gameObject.GetComponent<Animator>().Play("WIN00", -1, 0f);

            //4s后更换场景
            Invoke("nextLevel", 4f);
        }
    }



}
