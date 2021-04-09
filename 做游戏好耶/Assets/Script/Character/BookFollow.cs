using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;

public class BookFollow : ItemFollow {
    //左下位置和右上位置
    //一定要初始化target
    public override void InitComponent () {
        //赋予第一个孩子的位置
        target = GameObject.FindWithTag ("Player").transform.Find("SelfObject").Find("BookPlace");
    }
    public override void Limit () { }
}