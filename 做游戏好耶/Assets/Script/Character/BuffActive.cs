/* using System;
using UnityEngine;

public class BuffActive : MonoBehaviour {
    //持续时间
    [HideInInspector] public float stayTime;
    //计时器
    private float Timer;
    private void Update () {
        if (Timer > 0) {
            Timer -= 1;
        } else {
            StopActive ();
        }
    }
    public void StopActive () {
        this.gameObject.SetActive (false);
        this.enabled = false;
    }
} */