using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //侦测周围敌人条件
    public class LostTargetTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.LostTarget;
        }
        //判断条件：周围有敌人
        public override bool HandleTrigger (FSMBase fsm) {
            //如果敌人的transform不为空（即周围有敌人，而且是最近的敌人）
            return fsm.targetTF == null;
        }
    }
}