using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class MovePositionPathFinding : MonoBehaviour, IMovePosition {
    private int pathIndex = -1;
    private List<PathNode> pathList;
    public void SetPosition (Vector3 movePosition) {
        //索引值初始化
        pathIndex = -1;
        //限制区域：地图左下和右上，因为是地牢，所以不会占很多格子
        pathList = EveryFunction.GetPath (transform.position, movePosition);
        //路径点1：一定是自己位置上的格子，所以要算如果路径点>1，说明还没到目标位置
        if (pathList != null && pathList.Count > 1) {
            pathIndex = 1;
        }
    }
    public void SetPathList (List<PathNode> pathList) {
        //直接导入pathList
        this.pathList = pathList;
        pathIndex = 1;
    }
    //路径移动
    public void PathMoving () {
        if (pathIndex != -1) {
            //移动到下一个点位
            Vector3 nextPathPosition = pathList[pathIndex].GetWorldCenterPosition ();
            Vector3 moveVelocity = (nextPathPosition - transform.position).normalized;
            //调用移动方法
            GetComponent<IMoveVelocity> ().SetVelocity (moveVelocity);
            //判断是否到下一个点的位置上
            if (Vector3.Distance (nextPathPosition, transform.position) < ConstantList.PATHDISTANCE) {
                pathIndex++;
                if (pathIndex >= pathList.Count) {
                    //结束路径
                    pathIndex = -1;
                }
            }
        } else {
            //停止
            StopPosition ();
        }
    }
    public void StopPosition () {
        pathList = null;
        GetComponent<IMoveVelocity> ().SetVelocity (Vector3.zero);
    }

}