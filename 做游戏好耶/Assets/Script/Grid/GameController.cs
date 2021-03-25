using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class GameController : MonoBehaviour {
    [Header("PathGrid Setting")]
    public Transform leftDownTransform;
    public Transform rightUpTransform;
    
    private static GameController gameController;
    static public GameController getGameController () {
        if (gameController == null) {
            gameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();
        }
        return gameController;
    }
    private void Start () {
        //默认设置的第一个元素为左下，第二个元素为右上
        Init ();
    }
    public void Init () {
        gameController = this;
        PathGrid pathGrid = new PathGrid (leftDownTransform.position, rightUpTransform.position);
        EveryFunction.SetPathFinding (pathGrid);
    }

}