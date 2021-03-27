using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class DeadState : IState {
    private IStateMachine stateMachine;
    private CharacterBase characterBase;
    public DeadState (IStateMachine stateMachine, CharacterBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
    }
    public void Start () {
        //初始化
        characterBase.GetSelfObject ().GetComponent<Animator> ().SetBool ("isDead", true);
        MonoBehaviour.Destroy (characterBase.gameObject, 0.5f);
    }
    public void Update () { }
    public void Exit () { }
}