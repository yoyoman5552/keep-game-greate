using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //追击状态
    public class ChaseState : FSMState {
        //        private float oriDistance;
        //一定要初始化stateID,而且要初始化对
        public override void Init () {
            stateID = FSMStateID.Chase;
        }
        public override void EnterState (FSMBase fsm) {
            base.EnterState (fsm);
            //设置速度
            fsm.characterStatus.SetMoveSpeed (fsm.runPercent);
            //播放待机动画
            //            fsm.animator.SetBool()
        }
        public override void ActionState (FSMBase fsm) {
            base.ActionState (fsm);
            //不断更新抵达目标位置的路径表
            //获取位置
            List<PathNode> pathList = fsm.GetPath (fsm.targetTF.position);
            //如果有路径而且不为路径长度不为1（1为自身位置）
            if (pathList != null && pathList.Count > 1) {
                //移动方法的路径列表设置
                fsm.GetComponent<IMovePosition> ().SetPathList (pathList);
                //开始移动
                fsm.GetComponent<IMovePosition> ().PathMoving ();
            }
        }
        public override void ExitState (FSMBase fsm) {
            //停止移动
            fsm.GetComponent<IMovePosition> ().StopPosition ();
        }
    }
}