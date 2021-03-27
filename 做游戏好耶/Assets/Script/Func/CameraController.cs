using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;

public class CameraController : MonoBehaviour {
    //相机晃动
    public IEnumerator CameraShake (float _maxTime, float _amount) {
        Debug.Log("Start");
        Vector3 originalPos = transform.localPosition;
        float shakeTime = 0f;
        while (shakeTime < _maxTime) {
            float x = Random.Range (-1, 1) * _amount;
            float y = Random.Range (-1, 1) * _amount;
            transform.localPosition = new Vector3 (x, y, originalPos.z);
            shakeTime += Time.deltaTime;
            yield return new WaitForSeconds (0f);
        }
    }
}