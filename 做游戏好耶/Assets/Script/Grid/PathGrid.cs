using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PathGrid {
    Vector3Int leftDownPosition;
    Vector3Int rightUpPosition;
    private int width;
    private int height;
    private Grid<PathNode> grid;
    public PathGrid (Vector3 leftDownPos, Vector3 rightUpPos) {
        leftDownPosition = EveryFunction.FloorToInt (leftDownPos);
        rightUpPosition = EveryFunction.FloorToInt (rightUpPos);
        width = Mathf.Abs (leftDownPosition.x - this.rightUpPosition.x);
        height = Mathf.Abs (leftDownPosition.y - this.rightUpPosition.y);
        grid = new Grid<PathNode> (width, height, 1f,
            leftDownPosition, (Grid<PathNode> g, int x, int y) => new PathNode (g, x, y));

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (isAWall (x, y)) {
//                     Debug.Log (grid.GetTGridObject (x, y).ToString ());
                     grid.GetTGridObject (x, y).SetIsThroughable (false);
                } else grid.GetTGridObject (x, y).SetIsThroughable (true);
            }
        }
    }
    public Grid<PathNode> GetGrid () {
        return grid;
    }
    public bool isAWall (int x, int y) {
        if (Physics2D.Raycast (grid.GetWorldCenterPosition (x, y), Vector3.forward,
                grid.GetCellsize (), LayerMask.GetMask ("Wall")).collider != null) return true;
        return false;
    }
}