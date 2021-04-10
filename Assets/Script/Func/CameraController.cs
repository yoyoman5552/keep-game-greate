using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;

public class CameraController : ItemFollow {
    //左下位置和右上位置
    public Transform LDP;
    public Transform RUP;
    //一定要初始化target
    public override void InitComponent () {
        target = GameObject.FindWithTag ("Player").transform;
    }
    public override void Limit () {
        //限制摄像机的位置
        transform.position = new Vector3 (
            Mathf.Clamp (transform.position.x, LDP.position.x, RUP.position.x),
            Mathf.Clamp (transform.position.y, LDP.position.y, RUP.position.y),
            transform.position.z);
    }
    //相机晃动
    public void CameraShake (float _maxTime, float _amount) {
        StartCoroutine (CameraShaker (_maxTime, _amount));
    }
    //相机晃动器
    private IEnumerator CameraShaker (float _maxTime, float _amount) {
        Debug.Log ("Shaking");
        Vector3 originalPos = transform.localPosition;
        float shakeTime = 0f;
        while (shakeTime < _maxTime) {
            float x = Random.Range (-1, 1) * _amount;
            float y = Random.Range (-1, 1) * _amount;
            transform.position = target.position + new Vector3 (x, y, transform.position.z);
            shakeTime += Time.deltaTime;
            yield return new WaitForSeconds (0f);
        }
    }
}