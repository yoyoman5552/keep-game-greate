using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class BodyDamage : SkillClass {
    //BodyDamage是一种特殊的攻击方式，它独立于状态机外，只属于Enemy的攻击
    public BodyDamage (IStateMachine stateMachine, IBase characterBase) {
        Init (stateMachine, characterBase);
    }
    public override void Init (IStateMachine stateMachine, IBase characterBase) {
        //先运行基类的初始化
        localDamage = 0;
        base.Init (stateMachine, characterBase);
        //bodyDamage不一样，它直接放在人物身上
        skillCollider.enabled = true;
    }
    private void Start () {
        Init (GetComponent<IStateMachine> (), GetComponent<IBase> ());
    }
    private void Update () {
        //倒计时
        if (m_cdTimer > 0) {
            m_cdTimer -= Time.deltaTime;
            //如果到达技能有效开始时间
        } else {
            skillCollider.enabled = true;
        }

    }
    public override void onUpdate () { }
    public override void onAttack () {
        //进入Cd
        m_cdTimer = cdTime;
        skillCollider.enabled = false;
    }
    private void OnTriggerEnter2D (Collider2D other) {
        //如果是敌人或者玩家 且不是自己的友军 bodyDamage判断方式
        if ((other.tag == "Enemy" || other.tag == "Player") && other.tag != characterBase.tag) {
            //如果现在已进入CD，说明技能已经在释放中
            if (m_cdTimer > 0) return;
            other.GetComponent<IBase> ().TakenDamage (localDamage + characterSelfDamage + Random.Range (minRandomDamage, maxRandomDamage), this);
            onAttack ();
        }
    }

}