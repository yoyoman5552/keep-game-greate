using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Character;
using UnityEngine;
namespace EveryFunc.FSM {
    //状态机基类
    public class FSMBase : MonoBehaviour {
        //状态列表
        private List<FSMState> statesList;
        //当前状态
        private FSMState currentState;
        //默认状态
        private FSMState defaultState;
        [Tooltip ("默认状态编号")]
        public FSMStateID DefaultStateID;
        [HideInInspector] public Animator animator;
        [HideInInspector] public CharacterBase characterStatus;
        private void Start () {
            //初始化Component的东西
            InitComponent ();
            //配置状态机
            ConfigFSM ();
            //查找默认状态：默认状态初始化
            InitDefaultState ();
        }
        public void InitComponent () {
            animator = GetComponentInChildren<Animator> ();
            characterStatus = GetComponent<CharacterBase> ();
        }
        public void InitDefaultState () {
            defaultState = statesList.Find (s => s.stateID == DefaultStateID);
            currentState = defaultState;
            currentState.EnterState (this);
        }
        //配置状态机
        private void ConfigFSM () {
            statesList = new List<FSMState> ();
            //创建状态对象
            FSMState idle = new IdleState ();
            FSMState dead = new DeadState ();
            //添加映射(AddMap)
            idle.addMap (FSMTriggerID.NoHealth, FSMStateID.Dead);
            //加入状态机
            statesList.Add (idle);
            statesList.Add (dead);
        }
        //--创建状态对象
        //--设置状态(AddMap)

        //每帧处理的逻辑
        private void Update () {
            //每帧判断条件，如果有条件满足了就切换状态
            //判断当前状态条件
            currentState.DetectTriggers (this);
            //执行当前逻辑
            currentState.ActionState (this);
        }
        //切换状态
        public void ChangeActiveState (FSMStateID stateID) {
            //更新当前状态
            //退出当前状态
            currentState.ExitState (this);
            //切换状态
            //如果需要切换的状态编号是 Default 就直接返回默认状态,否则返回查找的状态
            currentState = stateID == FSMStateID.Default?defaultState : statesList.Find (s => s.stateID == stateID);
            //进入下一个状态
            currentState.EnterState (this);
        }
    }
}