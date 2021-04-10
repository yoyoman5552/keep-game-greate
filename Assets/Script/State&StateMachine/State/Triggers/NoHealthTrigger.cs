using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //没有生命条件
    public class NoHealthTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.NoHealth;
        }
        //判断条件：当前生命值是否小于0
        public override bool HandleTrigger (FSMBase fsm) {
            //生命值是否小于0
            return fsm.characterStatus.data.health <= 0;
        }
    }
}