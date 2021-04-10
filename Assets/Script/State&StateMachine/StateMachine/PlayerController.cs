using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Character;
using EveryFunc.Skill;
using UnityEngine;
namespace EveryFunc.FSM {
    //人物状态机类
    public class PlayerController : FSMBase {
        public override void InitComponent () {
            //状态机基类的初始化
            base.InitComponent ();
            //人物状态机的初始化
        }
        //状态机配置
        public override void ConfigFSM () {
            statesList = new List<FSMState> ();
            //创建状态对象
            FSMState gaming = new GamingState ();
            //添加映射(AddMap) 

            //加入状态机
            statesList.Add (gaming);
        }
        public override void Update () {
            base.Update ();
            //人物翻转
            characterStatus.Flip (EveryFunction.GetMouseWorldPosition ().x - transform.position.x);
        }
    }
}