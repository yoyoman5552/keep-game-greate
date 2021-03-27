using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class AttackState : IState {
    private IStateMachine stateMachine;
    private CharacterBase characterBase;
    private ISkill skill;
    public AttackState (IStateMachine stateMachine, CharacterBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
        skill = characterBase.GetComponentInChildren<ISkill> ();
        skill.Init (stateMachine, characterBase);
    }
    public void Start () {

        //初始化
    }
    public void Update () { }
    public void Exit () { }
}