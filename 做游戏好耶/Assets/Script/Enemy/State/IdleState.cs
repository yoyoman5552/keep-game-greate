using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class IdleState : IState {
    private IStateMachine stateMachine;
    private CharacterBase characterBase;
    private float idleTimer;
    public IdleState (IStateMachine stateMachine, CharacterBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
        idleTimer = 0;
    }
    public void Start () {
        //播放动画
    }
    public void Update () {
        idleTimer += Time.deltaTime;
        if (idleTimer >= characterBase.idleTime) {
            stateMachine.ChangeState (StateType.Patrol);
        }
    }
    public void Exit () {
        idleTimer = 0;
    }
}