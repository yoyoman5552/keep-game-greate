using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class AttackState : IState {
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