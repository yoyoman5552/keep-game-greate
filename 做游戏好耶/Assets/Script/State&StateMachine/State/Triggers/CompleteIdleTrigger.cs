using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //完成待机条件
    public class CompleteIdleTrigger : FSMTrigger {
        //一定要初始化ID
        public override void Init () {
            triggerID = FSMTriggerID.CompleteIdle;
        }
        //判断条件：闲置时间是否完成
        public override bool HandleTrigger (FSMBase fsm) {
            //idle计时器是否<=0
            return fsm.idleTimer < 0;
        }
    }
}