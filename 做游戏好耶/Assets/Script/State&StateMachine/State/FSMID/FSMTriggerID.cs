using UnityEngine;

//状态机条件枚举
namespace EveryFunc.FSM {
    public enum FSMTriggerID {
        //没有生命
        NoHealth,
        //发现目标
        SawTarget,
        //到达目标
        ReachedTarget,
        //目标被击杀
        KilledTarget,
        //超出攻击范围
        OutOfAttackRange,
        //丢失目标
        LostTarget,
        //完成巡逻
        CompletePatrol
    }
}