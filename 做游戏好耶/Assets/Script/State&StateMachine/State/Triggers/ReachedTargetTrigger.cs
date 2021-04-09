using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //到达敌人条件
    public class ReachedTargetTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.ReachedTarget;
        }
        //判断条件：敌人的距离已到达攻击范围内 
        public override bool HandleTrigger (FSMBase fsm) {
            //敌人和自身距离小于攻击范围
            return Vector3.Distance (fsm.transform.position, fsm.targetTF.position) < fsm.attackDistance;
        }
    }
}