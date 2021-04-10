using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //攻击状态
    public class AttackState : FSMState {
        //一定要初始化stateID,而且要初始化对
        public override void Init () {
            stateID = FSMStateID.Attack;
        }
        //攻击间隔器，Time.time为时时时间 
        private float atkTime;
        public override void ActionState (FSMBase fsm) {
            base.EnterState (fsm);
            if (atkTime <= Time.time) {
                //不用播放动画，技能里有动画播放器
                fsm.skillSystem.UseRandomSkill ();
                //攻击间隔
                atkTime = Time.time + fsm.attackInterval;

            }
        }
    }
}