using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerAttackState : IState {
    private IStateMachine stateMachine;
    private IBase characterBase;
    public PlayerAttackState (IStateMachine stateMachine, IBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
    }
    public void Start () {

    }
    public void Update () { }
    public void Exit () { }
}