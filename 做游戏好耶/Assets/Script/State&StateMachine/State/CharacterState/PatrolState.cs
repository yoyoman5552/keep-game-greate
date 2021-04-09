using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.FSM {
    //随机移动
    public class PatrolState : FSMState {
        //一定要初始化stateID,而且要初始化对
        public override void Init () {
            stateID = FSMStateID.Patrol;
        }
        public override void EnterState (FSMBase fsm) {
            base.EnterState (fsm);

            //设置移动速度
            fsm.characterStatus.SetMoveSpeed (fsm.movePercent);

            //获取随机路径：自身初始位置，半径为搜索半径的圆圈内，最低需为1格
            Vector3 movePosition;
            List<PathNode> pathList = fsm.FindRandomPos (out movePosition);

            //设置路径位置
            fsm.SetPatrolPosition (movePosition);
            //移动方法的路径列表设置
            fsm.GetComponent<IMovePosition> ().SetPathList (pathList);

            //播放动画
            //            fsm.animator.SetBool()
        }
        public override void ActionState (FSMBase fsm) {
            //开始移动
            fsm.GetComponent<IMovePosition> ().PathMoving ();
        }
        public override void ExitState (FSMBase fsm) {
            //停止移动
            fsm.GetComponent<IMovePosition> ().StopPosition ();
        }

    }
}