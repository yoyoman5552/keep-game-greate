using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //敌人超出攻击范围条件
    public class OutOfAttackRangeTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.OutOfAttackRange;
        }
        //判断条件：敌人的距离超出攻击范围 
        public override bool HandleTrigger (FSMBase fsm) {
            //敌人和自身距离大于攻击范围
            return Vector3.Distance (fsm.transform.position, fsm.targetTF.position) > fsm.attackDistance;
        }
    }
}