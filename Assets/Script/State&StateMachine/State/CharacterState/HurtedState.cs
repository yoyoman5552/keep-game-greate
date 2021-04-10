using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //闲置状态
    public class HurtedState : FSMState {
        //idle时间
        private float hurtedTime;
        //一定要初始化stateID,而且要初始化对
        public override void Init () {
            stateID = FSMStateID.Hurted;
        }
        public override void EnterState (FSMBase fsm) {
            base.EnterState (fsm);
            hurtedTime = fsm.hurtedTimer;
            fsm.serachDistance *= 2;
            //播放待机动画
            //            fsm.animator.SetBool()
        }
        public override void ActionState (FSMBase fsm) {
            //倒计时
            hurtedTime -= Time.deltaTime;
            if (hurtedTime <= 0) {
                this.addMap (FSMTriggerID.DetectTarget, FSMStateID.Chase);
                this.addMap (FSMTriggerID.LostTarget, FSMStateID.Patrol);
            }
        }

        public override void ExitState (FSMBase fsm) {
            //删除映射
            ClearAll ();
        }
    }
}