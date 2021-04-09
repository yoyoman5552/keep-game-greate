using UnityEngine;

//状态机条件枚举
namespace EveryFunc.FSM {
    public enum FSMTriggerID {
        //没有生命
        NoHealth,
        //被攻击了
        IsHurted,
        //发现目标
        DetectTarget,
        //到达目标
        ReachedTarget,
        //目标被击杀
        //超出攻击范围
        OutOfAttackRange,
        //丢失目标
        LostTarget,
        //完成巡逻
        CompletePatrol,
        //闲置完成
        CompleteIdle,

        //人物条件
        UION
    }
}