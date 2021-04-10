using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class GameController : MonoSingleton<GameController> {
    // 单例模式
    [Header ("PathGrid Setting")]
    public Transform leftDownTransform;
    public Transform rightUpTransform;
    public Canvas canvas;
    //伤害数字
    public GameObject damageText;
    [HideInInspector] public CameraController cameraController;
    private void Start () {
        //默认设置的第一个元素为左下，第二个元素为右上
        Init ();
    }
    public void Init () {
        //初始化路径网格
        PathGrid pathGrid = new PathGrid (leftDownTransform.position, rightUpTransform.position);
        EveryFunction.InitPathFinding (pathGrid);
        cameraController = GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ();
    }

}