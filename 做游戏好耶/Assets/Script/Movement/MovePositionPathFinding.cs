using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class MovePositionPathFinding : MonoBehaviour, IMovePosition {
    private float reachedMinPathPositionDistance = 0.3f; //到达路径点的最短距离
    private int pathIndex = -1;
    private List<PathNode> pathList;
    public void SetPosition (Vector3 movePosition) {
        pathIndex = -1;
        pathList = EveryFunction.getPath (transform.position, movePosition, GameController.Instance.leftDownTransform.position, GameController.Instance.rightUpTransform.position);
        if (pathList != null) {
            pathIndex = 1;
        }
    }
    public void SetPosition (Vector3 movePosition, Vector3 leftDownPosition, Vector3 rightUpPosition) {
        pathIndex = -1;
        pathList = EveryFunction.getPath (transform.position, movePosition, leftDownPosition, rightUpPosition);
        if (pathList != null) {
            pathIndex = 1;
        }
    }
    private void Update () {
        if (pathIndex != -1) {
            //pathList为1说明是到达自己点的位置上
            if (pathList.Count == 1) {
                pathIndex = -1;
                return;
            }
            //移动到下一个点位
            Vector3 nextPathPosition = pathList[pathIndex].GetWorldCenterPosition ();
            Vector3 moveVelocity = (nextPathPosition - transform.position).normalized;
            GetComponent<IMoveVelocity> ().SetVelocity (moveVelocity);
            //判断是否到下一个点的位置上
            if (Vector3.Distance (nextPathPosition, transform.position) < reachedMinPathPositionDistance) {
                pathIndex++;
                if (pathIndex >= pathList.Count) {
                    //结束路径
                    pathIndex = -1;
                }
            }
        } else {
            //停止
            pathList = null;
            GetComponent<IMoveVelocity> ().SetVelocity (Vector3.zero);
        }
    }
    public void StopPosition () {
        pathList=null;
        GetComponent<IMoveVelocity> ().SetVelocity (Vector3.zero);
    }

}