using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionDirect : MonoBehaviour, IMovePosition {
    private Vector3 movePosition;
    public void SetPosition (Vector3 movePosition) {
        this.movePosition = movePosition;
    }

    public void SetPosition (Vector3 movePosition, Vector3 leftDownPosition, Vector3 rightUpPosition) { }

    private void Update () {
        Vector3 moveDir = (movePosition - transform.position).normalized;
        GetComponent<IMoveVelocity> ().SetVelocity (moveDir);
    }
    public void StopPosition () {
        GetComponent<IMoveVelocity> ().SetVelocity (Vector3.zero);
    }
}