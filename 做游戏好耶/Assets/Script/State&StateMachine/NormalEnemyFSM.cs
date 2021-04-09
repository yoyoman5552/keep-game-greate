using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Character;
using EveryFunc.Skill;
using UnityEngine;

namespace EveryFunc.FSM {
    public class NormalEnemyFSM : FSMBase {
        public override void ConfigFSM () {
            statesList = new List<FSMState> ();
            //创建状态对象
            FSMState idle = new IdleState ();
            FSMState dead = new DeadState ();
            FSMState patrol = new PatrolState ();
            FSMState chase = new ChaseState ();
            FSMState attack = new AttackState ();
            FSMState hurted = new HurtedState ();
            //添加映射(AddMap) 
            //idle的映射
            idle.addMap (FSMTriggerID.NoHealth, FSMStateID.Dead);
            idle.addMap (FSMTriggerID.IsHurted, FSMStateID.Hurted);
            idle.addMap (FSMTriggerID.DetectTarget, FSMStateID.Chase);
            idle.addMap (FSMTriggerID.CompleteIdle, FSMStateID.Patrol);

            //patrol的映射
            patrol.addMap (FSMTriggerID.NoHealth, FSMStateID.Dead);
            patrol.addMap (FSMTriggerID.IsHurted, FSMStateID.Hurted);
            patrol.addMap (FSMTriggerID.DetectTarget, FSMStateID.Chase);
            patrol.addMap (FSMTriggerID.CompletePatrol, FSMStateID.Default);

            //chase的映射
            chase.addMap (FSMTriggerID.NoHealth, FSMStateID.Dead);
            chase.addMap (FSMTriggerID.IsHurted, FSMStateID.Hurted);
            chase.addMap (FSMTriggerID.LostTarget, FSMStateID.Idle);
            chase.addMap (FSMTriggerID.ReachedTarget, FSMStateID.Attack);

            //attack的映射
            attack.addMap (FSMTriggerID.OutOfAttackRange, FSMStateID.Chase);

            //加入状态机
            statesList.Add (idle);
            statesList.Add (dead);
            statesList.Add (patrol);
            statesList.Add (chase);
            statesList.Add (attack);
            statesList.Add (hurted);

        }
    }
}