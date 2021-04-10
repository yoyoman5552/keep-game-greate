using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour {
    [Tooltip ("选择器游戏物体名称")]
    public string selectedName = "Selected";
    [Tooltip ("显示时间")]
    public float displayTime = 3;
    private GameObject selectedGO;
    private float hideTime=0;
    void Start () {
        selectedGO = transform.Find (selectedName).gameObject;
    }

    public void setSelectedActive (bool state) {

        //设置选择器激活状态
        selectedGO.SetActive (state);
        //如果是激活状态，则hideTime（关闭时间）重置为Time.time+3:一段时间后取消选择
        this.enabled = state; //该脚本激活状态设置（update调用和停止）
        if (state) {
            hideTime = Time.time + displayTime;
        }
    }
    private void Update () {
        if (hideTime <= Time.time) {
            setSelectedActive (false);
        }
    }
}