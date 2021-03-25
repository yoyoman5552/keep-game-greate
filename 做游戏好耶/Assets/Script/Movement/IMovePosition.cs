using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovePosition {
    void SetPosition (Vector3 movePosition);
    void SetPosition (Vector3 movePosition, Vector3 leftDownPosition, Vector3 rightUpPosition);
    void StopPosition();
}