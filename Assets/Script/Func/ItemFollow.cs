using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;

public abstract class ItemFollow : MonoBehaviour {
    //移动速度
    public float moveSpeed;
    [HideInInspector] public Transform target;
    //要求子类一定要实现目标初始化
    public abstract void InitComponent ();
    private void Start () {
        //初始化target
        InitComponent();
    }
    private void LateUpdate () {
        transform.position = Vector3.Lerp (transform.position, new Vector3 (target.position.x, target.position.y, transform.position.z), moveSpeed * Time.deltaTime);
        //限制
        Limit();
    }
    public abstract void Limit();
}