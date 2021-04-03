using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
[Serializable]
public class SkillData {
    //技能ID
    public int skillId;
    //技能名称
    public string name;
    //技能描述
    public string description;
    //冷却类型
    public CDType cd;
    //冷却时间
    public float cdTime;
    //冷却计时器
    [HideInInspector] public float cdTimer;
    //攻击距离
    public float attackDistance;
    //攻击角度
    public float attackAngle;
    //攻击目标tags
    public string[] attackTargetTags;
    //攻击目标对象数组
    [HideInInspector] public Transform[] attackTargets;
    //技能影响类型
    public string[] impactType = { "Strke" };
    //连击的下一个技能编号
    public int nextSkillId;
    //伤害类型
    public DamageType damageType;
    //伤害比率
    public float atkRatio;
    //仇恨倍率
    public float tpsRatio;
    //读取时间
    public float readTime;
    //持续时间
    public float durationTime;
    //伤害间隔
    public float atkInterval;
    //技能所属
    [HideInInspector] public GameObject owner;
    //技能预制件名称
    public string prefabName;
    //预制件对象
    [HideInInspector] public GameObject skillPrefab;
    //人物动画名称
    public string animationName;
    //受击特效名称
    public string hitFxName;
    //受击特效预制件
    [HideInInspector] public GameObject hitFxPrefab;
    //技能等级
    public int level;
    //攻击类型
    public AttackType attackType;
    //选择类型
    public SelectorType selectorType;
    //技能是否跟随角色
    public bool isFollowCharacter;
}