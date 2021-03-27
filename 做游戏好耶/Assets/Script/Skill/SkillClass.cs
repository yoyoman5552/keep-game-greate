using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public abstract class SkillClass : MonoBehaviour, ISkill {
    //自身的人物状态和状态机
    protected IBase characterBase;
    protected IStateMachine stateMachine;
    //技能本身伤害和人物的附加伤害
    public int localDamage;
    protected int characterSelfDamage;
    protected int maxRandomDamage;
    protected int minRandomDamage;
    //动画Animator和collider触发器
    protected Animator animator;
    protected Collider2D skillCollider;
    //技能的Vector变量：看技能需求是朝向、技能位置、或是技能对象
    protected Vector3 targetPosition;
    //技能cd
    [Header ("技能CD")]
    public float cdTime;
    public float m_cdTimer;
    [Header ("有效伤害时间段")]
    public float skillStartTime;
    public float skillEndTime;
    public virtual void Init (IStateMachine stateMachine, IBase characterBase) {
        //因为技能是预制体，所以无法单靠创建脚本而初始化，故设置了Init来初始化这两项
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
        //其实onStart现在的作用和Init差不多啦，都是初始化，但我规定要先Init再onStart
        animator = this.GetComponent<Animator> ();
        skillCollider = this.GetComponent<Collider2D> ();
        characterSelfDamage = characterBase.selfDamage;
        minRandomDamage = characterBase.minRandomDamage;
        maxRandomDamage = characterBase.maxRandomDamage;
        skillCollider.enabled = false;
        //反转下开始时间和结束时间
        skillStartTime = cdTime - skillStartTime;
        skillEndTime = cdTime - skillEndTime;
    }
    public virtual void onStart (Vector3 targetPosition) {
        //目标位置初始化
        this.targetPosition = targetPosition;
    }
    public virtual void onAttack () {

    }
    public virtual void onUpdate () {
        //技能的cd计算和技能是否有效判定
        //倒计时
        if (m_cdTimer > 0) {
            m_cdTimer -= Time.deltaTime;
            //如果到达技能有效开始时间
            if (m_cdTimer < skillStartTime) {
                //但是如果到达了技能有效结束时间
                if (m_cdTimer < skillEndTime) {
                    skillCollider.enabled = false;
                } else { //否则就为技能有效时间段内
                    skillCollider.enabled = true;
                }
            }
        }
    }

    public virtual void onExit () {

    }
    public IEffect GetDamageEffect () { //返回现在的技能效果
        return GetComponent<IEffect> ();
    }
    public IBase GetBase () {
        return characterBase;
    }
    public void SetTargetPosition (Vector3 targetPosition) {
        this.targetPosition = targetPosition;
    }
}