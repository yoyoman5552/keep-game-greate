using UnityEngine;

//状态机状态枚举
namespace EveryFunc.FSM {
    public enum FSMStateID {
        //没有状态
        None,
        //默认
        Default,
        //死亡
        Dead,
        //闲置
        Idle,
        //追击
        Pursuit,
        //攻击
        Attack,
        //巡逻
        Patrol
    }
}