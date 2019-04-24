using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class talkable : MonoBehaviour {

    public Flowchart talkFlowchart;
    public string onTalkZone;
    private Block targetBlock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //玩家进入对话范围触发对话
            targetBlock = talkFlowchart.FindBlock(onTalkZone);
            talkFlowchart.ExecuteBlock(targetBlock);
        }
    }


}
