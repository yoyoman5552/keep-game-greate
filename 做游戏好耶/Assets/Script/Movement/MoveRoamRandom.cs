using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class MoveRoamRandom : MonoBehaviour {
    public Transform leftDownTransform;
    public Transform rightUpTransform;
    private float randomDistanceX;
    private float randomDistanceY;
    private float arrivedAtPositionMinDistance = 1f; //到达目标点的最短距离
    private Vector3 startPosition;
    private Vector3 targetMovePosition;
    private bool isWalking;
    private void Awake () {
       // startPosition = this.transform.position;
    }
    private void Start () {
        randomDistanceX = (rightUpTransform.position.x - leftDownTransform.position.x) / 2;
        randomDistanceY = (rightUpTransform.position.y - leftDownTransform.position.y) / 2;
        SetTargetMovePosition ();

    }
    public void SetTargetMovePosition () {
        targetMovePosition = startPosition + EveryFunction.GetRandomDir () * Random.Range (randomDistanceX, randomDistanceY);
        isWalking = false;
    }
    private void Update () {
        if (Vector3.Distance (transform.position, targetMovePosition) < arrivedAtPositionMinDistance) {
            //重设一个目标点
            SetTargetMovePosition ();
            //            Debug.Log ("Move done,now target position:" + targetMovePosition);
        }
        if (!isWalking) SetMovePosition ();
    }
    private void SetMovePosition () {
        //如果有路径就进行移动
        if (EveryFunction.getPath (transform.position, targetMovePosition, leftDownTransform.position, rightUpTransform.position) != null) {
            GetComponent<IMovePosition> ().SetPosition (targetMovePosition, leftDownTransform.position, rightUpTransform.position);
            isWalking = true;
        } else {
            //没有路径就直接归为当前位置，让程序再随机一次（等于跳过这次移动）
            targetMovePosition = transform.position;
        }
    }
    public void setLimitArea (Vector3 leftDownPosition, Vector3 rightUpPosition) {
        this.leftDownTransform.position = leftDownPosition;
        this.rightUpTransform.position = rightUpPosition;
    }
}