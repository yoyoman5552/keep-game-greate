using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class AttackState : IState {
    //PatrolState的代码基本和MoveRoamRandom相同，MoveRoamRandom的作用是人物装上之后就只会移动
    //MoveRoamRandom如果给不需要对话的人装上，变成只会移动的npc
    private IStateMachine stateMachine;
    private CharacterBase characterBase;
    public AttackState (IStateMachine stateMachine, CharacterBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
    }
    public void Start () {
        //初始化
    }
    public void Update () { }
    public void Exit () { }
}