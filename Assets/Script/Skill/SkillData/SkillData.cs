using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
[Serializable]
public class SkillData {
    [Tooltip ("技能ID")]
    public int skillId;
    [Tooltip ("技能名称")]
    public string name;
    [Tooltip ("技能描述")]
    public string description;
    [Tooltip ("冷却类型")]
    public CDType cd;
    [Tooltip ("冷却时间")]
    public float cdTime;
    [Tooltip ("冷却计时器")]
    [HideInInspector] public float cdTimer;
    [Tooltip ("攻击距离")]
    public float attackDistance;
    [Tooltip ("攻击角度")]
    public float attackAngle;
    [Tooltip ("攻击目标tags")]
    public string[] attackTargetTags;
    [Tooltip ("攻击目标对象数组")]
    [HideInInspector] public Transform[] attackTargets;
    [Tooltip ("技能影响类型")]
    public string[] impactType = { "Damage" };
    [Tooltip ("连击的下一个技能编号")]
    public int nextSkillId;
    [Tooltip ("伤害比率")]
    public float atkRatio;
    [Tooltip ("仇恨倍率")]
    public float tpsRatio;
    [Tooltip ("读取时间")]
    public float readTime;
    [Tooltip ("持续时间")]
    public float durationTime;
    [Tooltip ("伤害间隔")]
    public float atkInterval;
    [Tooltip ("技能所属")]
    [HideInInspector] public GameObject owner;
    [Tooltip ("技能预制件名称")]
    public string prefabName;
    [Tooltip ("预制件对象")]
    [HideInInspector] public GameObject skillPrefab;
    [Tooltip ("人物动画名称")]
    public string characterAnimationName;
    [Tooltip ("受击特效名称")]
    public string hitFxName;
    [Tooltip ("受击特效预制件")]
    [HideInInspector] public GameObject hitFxPrefab;
    [Tooltip ("技能等级")]
    public int level;
    [Tooltip ("攻击类型")]
    public AttackType attackType;
    [Tooltip ("选择类型")]
    public SelectorType selectorType;
    [Tooltip ("技能是否跟随角色")]
    public bool isFollowCharacter;
    [Tooltip ("镜头摇晃时间")]
    public float CameraTime;
    [Tooltip ("镜头摇晃力度")]
    public float CameraPower;
}