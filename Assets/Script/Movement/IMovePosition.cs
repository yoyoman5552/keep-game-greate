using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovePosition {
    void SetPosition (Vector3 movePosition);
    void SetPathList(List<PathNode> pathList);
    void PathMoving();
     void StopPosition();
} 