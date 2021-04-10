using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionDirect : MonoBehaviour, IMovePosition {
    private Vector3 movePosition;
    public void SetPosition (Vector3 movePosition) {
        this.movePosition = movePosition;
    }
    public void SetPathList (List<PathNode> pathList) {

    }

    public void PathMoving () {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        GetComponent<IMoveVelocity> ().SetVelocity (moveDir);
    }
    public void StopPosition () {
        GetComponent<IMoveVelocity> ().SetVelocity (Vector3.zero);
    }
}