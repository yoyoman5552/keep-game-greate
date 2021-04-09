using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //闲置状态
    public class GamingState : FSMState {
        //人物Gaming状态
        //一定要初始化id
        public override void Init () {
            stateID = FSMStateID.Gaming;
        }
        public override void EnterState (FSMBase fsm) {
            base.EnterState (fsm);
            //人物移动类激活
            fsm.GetComponent<PlayerMovementKeys> ().enabled = true;
            //播放待机动画
            //            fsm.animator.SetBool()
        }
        public override void ActionState (FSMBase fsm) {
            
            if (Input.GetMouseButtonDown (0)) {

                int id = 1001;
                fsm.skillSystem.AttackUseSkill (id);
            }
            if (Input.GetMouseButtonDown (1)) { }
        }
        public override void ExitState (FSMBase fsm) {
            //人物移动类激活
            fsm.GetComponent<PlayerMovementKeys> ().enabled = false;
        }
    }
}