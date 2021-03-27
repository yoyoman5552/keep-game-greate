using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerDeadState : IState {
    private IStateMachine stateMachine;
    private IBase PlayerBase;
    public PlayerDeadState (IStateMachine stateMachine, IBase PlayerBase) {
        this.stateMachine = stateMachine;
        this.PlayerBase = PlayerBase;
    }
    public void Start () {
        //初始化
        PlayerBase.GetSelfObject ().GetComponent<Animator> ().SetBool ("isDead", true);
        MonoBehaviour.Destroy (PlayerBase.gameObject, 0.5f);
    }
    public void Update () { }
    public void Exit () { }
}