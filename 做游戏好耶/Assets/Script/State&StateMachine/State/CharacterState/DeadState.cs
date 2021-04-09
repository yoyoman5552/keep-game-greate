using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //死亡状态
    public class DeadState : FSMState {
        //一定要初始化stateID,而且要初始化对
        public override void Init () {
            stateID = FSMStateID.Dead;
        }
        public override void EnterState (FSMBase fsm) {
            base.EnterState (fsm);
            //死亡之后状态机禁用
            fsm.enabled = false;
            //播放待机动画
            fsm.animator.SetBool ("IsDead", true);
            //            fsm.animator.SetBool()
            //            GameObject.Destroy (fsm.gameObject, 1f);
            fsm.Invoke ("DeadDelay", 1f);
        }
    }
}