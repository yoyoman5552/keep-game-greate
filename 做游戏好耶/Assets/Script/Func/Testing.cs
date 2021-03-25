using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;

public class Testing : MonoBehaviour {
    private PathFinding pathFinding;
    private PathGrid pathGrid;
    public Transform pos1;
    public Transform pos2;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start () {
        pathGrid = new PathGrid (pos1.position, pos2.position);
        pathFinding = new PathFinding (pathGrid.GetGrid ());
        //pathFinding=new PathFinding(5,6,Vector3.zero);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (1)) {
            Vector3 mousePosition = EveryFunction.GetMouseWorldPosition ();
            pathFinding.GetGrid ().GetXY (mousePosition, out int x, out int y);
            pathFinding.GetGrid ().GetXY (playerTransform.position, out int oriX, out int oriY);
            pathFinding.GetGrid ().GetXY (GameController.getGameController ().leftDownTransform.position, out int minX, out int minY);
            pathFinding.GetGrid ().GetXY (GameController.getGameController ().rightUpTransform.position, out int maxX, out int maxY);
            List<PathNode> path = pathFinding.FindPath (oriX, oriY, x, y, minX, minY, maxX, maxY);
            if (path != null) {
                for (int i = 0; i < path.Count - 1; i++) {
                    Vector3 currentPos = pathFinding.GetGrid ().GetWorldCenterPosition (path[i].x, path[i].y);
                    Vector3 nextPos = pathFinding.GetGrid ().GetWorldCenterPosition (path[i + 1].x, path[i + 1].y);
                    Debug.DrawLine (currentPos, nextPos, Color.red, 100f);
                }
            }
        }
    }
}