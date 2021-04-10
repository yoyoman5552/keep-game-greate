using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EveryFunc {
    //cd类型
    public enum CDType {
        Cd,
        Gcd
    }
    //伤害类型
    public enum DamageType {
        Normal,
        ArmorBreaking
    }
    //攻击类型
    public enum AttackType {
        Single, //单体
        Multiple //多体
    }
    //选择方式类型
    public enum SelectorType {
        Sector, //扇形
        Rectangle //矩形
    }
    public enum StateType {
        Idle,
        Patrol,
        Chase,
        React,
        Attack,
        Hurt,
        Dead,

        //以上为Character的StateType
        //以下为Player的StateType
        Gaming,
        UI
    }
    //角色状态
    public enum CharacterType {
        Normal,
        Invincible
    }
    /*     public enum BuffType {
            ContinueDamage,
            ArmorBreaking,
            SpeedSlowDown,
            MaxHealthChange
        }
     */
    public static class ConstantList { //常量列表
        //短短的无敌时间，为了防止被同一次攻击伤害两次
        public const float WUDITIME = 0.05f;
        //被攻击时的颜色变化
        public const float HURTCOLORTIME = 0.3f;
        //path：判断是否走到路径点的距离
        public const float PATHDISTANCE = 0.3f;
    }
    public static class EveryFunction {
        private static int sortingOrder = 1;
        private static PathFinding pathFinding;
        public static PathFinding pathFind {
            get {
                if (pathFinding == null) {
                    //如果PathFinding是空的，则优先调用GameController的初始化（会初始化pahtFinding)
                    GameController.Instance.Init ();
                }
                return pathFinding;
            }
        }
        public static Vector3 GetMouseWorldPosition () { //获得鼠标位置
            Vector3 pos = GetMouseWorldPositionWithZ (Input.mousePosition);
            pos.z = 0;
            return pos;
        }
        public static Vector3 GetMouseWorldPositionWithZ (Vector3 screenPosition) { //从屏幕位置上获得世界位置
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
        public static void InitPathFinding (PathGrid pathGrid) {
            //初始化路径查找
            pathFinding = new PathFinding (pathGrid.GetGrid ());
        }
        //自己设置限制范围 获取路径
        public static List<PathNode> GetPathWithLimit (Vector3 originalPosition, Vector3 targetPosition, Vector3 leftDownPosition, Vector3 rightUpPosition) {
            pathFind.GetGrid ().GetXY (originalPosition, out int oriX, out int oriY);
            pathFind.GetGrid ().GetXY (targetPosition, out int tarX, out int tarY);
            pathFind.GetGrid ().GetXY (leftDownPosition, out int minX, out int minY);
            pathFind.GetGrid ().GetXY (rightUpPosition, out int maxX, out int maxY);
            return pathFind.FindPath (oriX, oriY, tarX, tarY, minX, minY, maxX, maxY);
        }
        //默认最大的限制范围 获取路径
        public static List<PathNode> GetPath (Vector3 originalPosition, Vector3 targetPosition) {
            pathFind.GetGrid ().GetXY (originalPosition, out int oriX, out int oriY);
            pathFind.GetGrid ().GetXY (targetPosition, out int tarX, out int tarY);
            return pathFind.FindPath (oriX, oriY, tarX, tarY, 0, 0, pathFind.GetGrid ().GetWidth (), pathFind.GetGrid ().GetHeight ());
        }
        public static List<PathNode> GetPathNodes (Vector3 originalPosition, Vector3 targetPosition) {
            pathFind.GetGrid ().GetXY (originalPosition, out int oriX, out int oriY);
            pathFind.GetGrid ().GetXY (targetPosition, out int tarX, out int tarY);
            return pathFind.FindPath (oriX, oriY, tarX, tarY, 0, 0, pathFind.GetGrid ().GetWidth (), pathFind.GetGrid ().GetHeight ());
        }
        public static Vector3 GetRandomDir () { //随机方向的单位向量（Vector3）
            return new Vector3 (UnityEngine.Random.Range (-1f, 1f), UnityEngine.Random.Range (-1f, 1f)).normalized;
        }
        public static float GetAngleOfMouseAndTransform (Transform originalTransform) { //计算鼠标和目标位置朝向之间的夹角
            return GetAngleOfTransform (originalTransform.position, GetMouseWorldPosition ());
        }
        public static float GetAngleOfTransform (Vector3 originalPosition, Vector3 targetPosition) { //计算目标位置和原位置朝向之间的夹角
            //物体转向
            Vector3 attackDirection = targetPosition - originalPosition;
            //返回计算的角度（Z轴）
            return Mathf.Atan2 (attackDirection.y, attackDirection.x) * Mathf.Rad2Deg; //Mathf.Rad2Deg:弧度转角度
        }
        public static Vector3 GetNormalDirection (Vector3 originalPosition, Vector3 targetPosition) {
            //获得从originalPosition到targetPosition的单位向量
            return (targetPosition - originalPosition).normalized;
        }

        //勾股定理求斜边
        public static float GetTriangleLongSide (float r, float l) {
            return (Mathf.Sqrt (r * r + l * l));
        }

        //ArrayHelper
        //Array内查找特定值
        public static T Find<T> (this T[] array, Func<T, bool> condition) {
            for (int i = 0; i < array.Length; i++) {
                if (condition (array[i])) {
                    return array[i];
                }
            }
            return default (T);
        }
        //Array内返回所有满足条件的对象 是对象不是值
        public static T[] FindAll<T> (this T[] array, Func<T, bool> condition) {
            //存储筛选出来满足条件的元素
            T[] result = new T[array.Length];
            for (int i = 0; i < array.Length; i++) {
                //筛选条件，满足条件就存入result中
                if (condition (array[i]))
                    result[i] = array[i];
            }
            return result;
        }
        //Array内筛选满足条件的值 是值不是对象
        public static Q[] Select<T, Q> (this T[] array, Func<T, Q> condition) {
            //存储筛选出来满足条件的元素
            Q[] result = new Q[array.Length];
            for (int i = 0; i < array.Length; i++) {
                //筛选条件，满足条件就存入result中
                result[i] = condition (array[i]);
            }
            return result;
        }

        //Array内查找最小的值
        public static T GetMin<T, Q> (this T[] array, Func<T, Q> condition) where Q : IComparable {
            T min = array[0];
            for (int i = 0; i < array.Length; i++) {
                if (condition (min).CompareTo (condition (array[i])) > 0) {
                    min = array[i];
                }
            }
            return min;
        }

    }
}