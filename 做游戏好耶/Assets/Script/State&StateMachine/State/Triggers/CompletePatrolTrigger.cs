using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //完成巡逻条件
    public class CompletePatrolTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.CompletePatrol;
        }
        //判断条件：和目标位置的距离是否小于PATHDISTANCE
        public override bool HandleTrigger (FSMBase fsm) {
            //是否到达目标位置,最低距离：1f，因为grid的位置和实际距离有些差异，所以设置一个1f的可控范围
            return Vector3.Distance (fsm.transform.position, fsm.patrolPosition) <= 1f;
        }
    }
}