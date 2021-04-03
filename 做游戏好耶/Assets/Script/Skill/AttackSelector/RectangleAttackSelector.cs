using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EveryFunc.Skill {
    //矩形
    public class RectangleAttackSelector : IAttackSelector {
        public List<Transform> targets = new List<Transform> ();
        public Transform[] SelectTarget (SkillData skillData, Transform skillTF) {
            //遍历查找
            return SearchAllTarget (skillData, skillTF);
        }
        public Transform[] SearchAllTarget (SkillData skillData, Transform skillTF) {
            //通过标签查找所有对象
            for (int i = 0; i < skillData.attackTargetTags.Length; i++) {
                GameObject[] targetOBJArray = GameObject.FindGameObjectsWithTag (skillData.attackTargetTags[i]);
                targets.AddRange (targetOBJArray.Select (g => g.transform));
            }

            //判断攻击范围(矩形)
            //勾股定理求斜边，cos和sin
            //计算长宽是否超出限制，再计算角度（是否在一个象限）
            targets = targets.FindAll (t => (
                (Vector3.Distance (t.position, skillTF.position) * Mathf.Sin (Vector3.Angle (skillTF.right, t.position - skillTF.position) * Mathf.Deg2Rad) <=
                    skillData.attackAngle / 2) &&
                (Vector3.Distance (t.position, skillTF.position) * Mathf.Cos (Vector3.Angle (skillTF.right, t.position - skillTF.position) * Mathf.Deg2Rad) <=
                    skillData.attackDistance) &&
                (Vector3.Angle (skillTF.right, t.position - skillTF.position) <= 90)));

            //筛选出活的角色
            targets.FindAll (t => t.GetComponent<IBase> ().health > 0);
            Transform[] results = targets.ToArray ();
            //返回目标（群攻/单攻)
            if (skillData.attackType == AttackType.Multiple || results.Length == 0)
                return results;

            Transform min = results.GetMin (t => Vector3.Distance (t.position, skillTF.position));
            return new Transform[] { min };
        }
    }
}