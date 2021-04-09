using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //没有生命条件
    public class IsHurtedTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.IsHurted;
        }
        //判断条件：是否被攻击了
        public override bool HandleTrigger (FSMBase fsm) {
            //isHurted是否为true
            return fsm.characterStatus.data.textureTime > 0;
        }
    }
}