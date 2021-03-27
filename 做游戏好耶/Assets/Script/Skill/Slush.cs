using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class Slush : SkillClass {
    //DamageType的Strike类的SpecialDamage为击退距离
    public Slush (IStateMachine stateMachine, IBase characterBase) {
        Init (stateMachine, characterBase);
    }
    public override void Init (IStateMachine stateMachine, IBase characterBase) {
        //先运行基类的初始化
        base.Init (stateMachine, characterBase);
    }
    /*     public override void onStart () {
            //onStart可以用于别处
        } */
    public override void onStart (Vector3 targetPosition) {
        //初始化
        base.onStart (targetPosition);
        //Slush需要的是设置好方向后就执行一次攻击
    }
    public override void onUpdate () {
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
    public override void onAttack () {
        //如果现在已进入CD，说明技能已经在释放中
        if (m_cdTimer > 0) return;
        //打开技能
        m_cdTimer = cdTime;
        //角度转换
        transform.rotation = Quaternion.Euler (0, 0, EveryFunction.GetAngleOfTransform (this.transform.position, targetPosition));
        //播放动画，攻击
        animator.Play ("Slush", 0, 0);
    }
    private void OnTriggerEnter2D (Collider2D other) {
        if ((other.tag == "Enemy" || other.tag == "Player") && other.tag != characterBase.tag) {
            other.GetComponent<IBase> ().TakenDamage (localDamage + characterSelfDamage + Random.Range (minRandomDamage, maxRandomDamage), this);
        }
    }
}