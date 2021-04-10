using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Character;
using EveryFunc.Skill;
using UnityEngine;
namespace EveryFunc.FSM {
    //状态机基类
    public abstract class FSMBase : MonoBehaviour {
        //状态列表
        protected List<FSMState> statesList;
        //当前状态
        protected FSMState currentState;
        //默认状态
        protected FSMState defaultState;
        [Tooltip ("默认状态编号")]
        public FSMStateID DefaultStateID;
        [Tooltip ("闲置时间")]
        public float idleTimer;
        [Tooltip("受伤的反应时间")]
        public float hurtedTimer=0.5f;
        [Tooltip ("搜敌检测距离")]
        public float serachDistance;
        [Tooltip ("攻击距离")]
        public float attackDistance;
        [Tooltip ("移动百分比")]
        public float movePercent;
        [Tooltip ("奔跑百分比")]
        public float runPercent;
        [Tooltip ("移动范围半径")]
        public float patrolRadius;
        [Tooltip ("目标标签，默认为玩家")]
        public string[] targetTags = { "Player" };
        [Tooltip ("攻击间隔")]
        public float attackInterval;
        //动画机
        [HideInInspector] public Animator animator;
        //角色属性
        [HideInInspector] public CharacterStatus characterStatus;
        //初始化位置
        [HideInInspector] public Vector3 startPosition;
        //Patrol路径点
        [HideInInspector] public Vector3 patrolPosition;
        //目标transform
        [HideInInspector] public Transform targetTF;
        //技能系统
        [HideInInspector] public CharacterSkillSystem skillSystem;

        private void Start () {
            //初始化Component的东西
            InitComponent ();
            //配置状态机
            ConfigFSM ();
            //查找默认状态：默认状态初始化
            InitDefaultState ();
        }
        public virtual void InitComponent () {
            //动画机
            animator = GetComponentInChildren<Animator> ();
            //角色数值
            characterStatus = GetComponent<CharacterStatus> ();
            //初始化位置
            startPosition = transform.position;
            //初始化技能管理器
            skillSystem = GetComponent<CharacterSkillSystem> ();
        }
        public void InitDefaultState () {
            defaultState = statesList.Find (s => s.stateID == DefaultStateID);
            currentState = defaultState;
            currentState.EnterState (this);
        }
        //配置状态机
        //根据人物状态需要设置状态机
        public abstract void ConfigFSM ();
        //--创建状态对象
        //--设置状态(AddMap)

        //每帧处理的逻辑
        public virtual void Update () {
            //检测是否被攻击了，被攻击就放大搜索圈
            HurtedSearch();
            //侦测周围是否有敌人
            DetectTarget ();
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
        //设置目标点
        public void SetPatrolPosition (Vector3 movePosition) {
            patrolPosition = movePosition;
        }
        //获取目标点（世界坐标）和路径列表（网格坐标）
        public List<PathNode> GetPath (Vector3 movePosition) {
            //返回路径表
            return EveryFunction.GetPath (transform.position, movePosition);
        }
        public List<PathNode> FindRandomPos (out Vector3 movePosition) {
            List<PathNode> pathList;
            do {
                //随机位置
                movePosition = startPosition + EveryFunction.GetRandomDir () * UnityEngine.Random.Range (0, patrolRadius);
                //到达该位置的路径表
                pathList = GetPath (movePosition);
                //条件：路径表为空，而且路径点数==1(第一个路径点就是自身的位置)时就需要重新选择位置
            } while (pathList == null || pathList.Count == 1);
            return pathList;
        }
        //查找目标
        public void DetectTarget () {
            SkillData data = new SkillData () {
                attackTargetTags = targetTags,
                attackDistance = serachDistance,
                attackAngle = 360,
                attackType = AttackType.Single
            };
            Transform[] targetArr = new SectorAttackSelector ().SelectTarget (data, transform);
            targetTF = targetArr.Length == 0 ? null : targetArr[0];
        }
        public void HurtedSearch () {
            //如果被攻击了，就放大检测敌人的范围
            if (characterStatus.data.isHurted) {
                serachDistance *= 2;
            }
        }
        public void DeadDelay () {
            gameObject.SetActive (false);
        }
    }
}