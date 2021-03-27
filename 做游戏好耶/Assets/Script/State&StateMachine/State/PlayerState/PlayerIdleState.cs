using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerIdleState : IState {
    //PatrolState的代码基本和MoveRoamRandom相同，MoveRoamRandom的作用是人物装上之后就只会移动
    //MoveRoamRandom如果给不需要对话的人装上，变成只会移动的npc
    private IStateMachine stateMachine;
    private IBase characterBase;
    private SpriteRenderer spriteRenderer; //获取人物的贴图属性
    public PlayerIdleState (IStateMachine stateMachine, IBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
        this.spriteRenderer = characterBase.GetSelfObject ().GetComponent<SpriteRenderer> ();
    }
    public void Start () {

    }
    public void Update () {

    }
    public void Exit () { }

}