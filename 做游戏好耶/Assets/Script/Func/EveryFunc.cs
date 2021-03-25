using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EveryFunc {
    public enum StateType {
        Idle,
        Patrol,
        Chase,
        React,
        Attack
    }
    public static class EveryFunction {

        private static int sortingOrder = 1;
        private static PathFinding pathFinding;
        public static PathFinding PathFind {
            get {
                if (pathFinding == null) {
                    //如果PathFinding是空的，则优先调用GameController的初始化（会初始化pahtFinding)
                    GameObject.FindWithTag ("GameController").GetComponent<GameController> ().Init ();
                }
                return pathFinding;
            }
        }
        public static Vector3 GetMouseWorldPosition () {
            return GetMouseWorldPositionWithZ (Input.mousePosition);
        }
        public static Vector3 GetMouseWorldPositionWithZ (Vector3 screenPosition) {
            return Camera.main.ScreenToWorldPoint (screenPosition);
        }
        public static TextMesh CreateWorldText (string text, Transform parent = null, Vector3 localPosition = default (Vector3), int fontsize = 35, Color color = default (Color), TextAnchor textAnchor = default (TextAnchor), TextAlignment textAlignment = default (TextAlignment)) {
            if (color == null) color = Color.white;
            return CreateWorldText (parent, text, localPosition, fontsize, color, textAnchor, textAlignment);
        }
        public static TextMesh CreateWorldText (Transform parent, string text, Vector3 localPosition, int fontsize, Color color, TextAnchor textAnchor, TextAlignment textAlignment) {
            GameObject gameObject = new GameObject ("World Text", typeof (TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent (parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh> ();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontsize;
            textMesh.color = color;
            textMesh.characterSize = 0.1f;
            textMesh.GetComponent<MeshRenderer> ().sortingOrder = sortingOrder + 100;
            return textMesh;
        }
        public static Vector3Int FloorToInt (Vector3 oriPos) {
            Vector3Int tarPos = Vector3Int.zero;
            tarPos.x = Mathf.RoundToInt (oriPos.x);
            tarPos.y = Mathf.RoundToInt (oriPos.y);
            tarPos.z = Mathf.RoundToInt (oriPos.z);
            return tarPos;
        }
        public static void SetPathFinding (PathGrid pathGrid) {
            pathFinding = new PathFinding (pathGrid.GetGrid ());
        }
        public static List<PathNode> getPath (Vector3 originalPosition, Vector3 targetPosition, Vector3 leftDownPosition, Vector3 rightUpPosition) {
            pathFinding.GetGrid ().GetXY (originalPosition, out int oriX, out int oriY);
            pathFinding.GetGrid ().GetXY (targetPosition, out int tarX, out int tarY);
            pathFinding.GetGrid ().GetXY (leftDownPosition, out int minX, out int minY);
            pathFinding.GetGrid ().GetXY (rightUpPosition, out int maxX, out int maxY);
            return pathFinding.FindPath (oriX, oriY, tarX, tarY, minX, minY, maxX, maxY);
        }
        public static List<PathNode> GetPathNodes (Vector3 originalPosition, Vector3 targetPosition) {
            pathFinding.GetGrid ().GetXY (originalPosition, out int oriX, out int oriY);
            pathFinding.GetGrid ().GetXY (targetPosition, out int tarX, out int tarY);
            return pathFinding.FindPath (oriX, oriY, tarX, tarY, 0, 0, pathFinding.GetGrid ().GetWidth (), pathFinding.GetGrid ().GetHeight ());
        }
        public static Vector3 GetRandomDir () { //随机方向的单位向量（Vector3）
            return new Vector3 (UnityEngine.Random.Range (-1f, 1f), UnityEngine.Random.Range (-1f, 1f)).normalized;
        }

    }
}