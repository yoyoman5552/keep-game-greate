using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //闲置状态
    public class IdleState : FSMState {
        //一定要初始化stateID,而且要初始化对
        public override void Init () {
            stateID = FSMStateID.Idle;
        }
        public override void EnterState (FSMBase fsm) {
            base.EnterState (fsm);

            //播放待机动画
            //            fsm.animator.SetBool()
        }
    }
}