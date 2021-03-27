using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class GamingState : IState, IStateMachine {
    private IStateMachine stateMachine;
    private PlayerBase playerBase;
    private ISkill leftMouseSkill;
    private ISkill rightMouseSkill;
    private float leftMouseSkillCDTime;
    private float rightMouseSkillCDTime;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState> ();
    private IState currentState;
    public GamingState (IStateMachine stateMachine, PlayerBase playerBase) {
        this.stateMachine = stateMachine;
        this.playerBase = playerBase;
        states.Add (StateType.Idle, new PlayerIdleState (this, playerBase));
        states.Add (StateType.Hurt, new PlayerHurtState (this, playerBase));
        states.Add (StateType.Dead, new PlayerDeadState (this, playerBase));
        ChangeState (StateType.Idle);
    }
    public void Start () {
        //初始化
        leftMouseSkill = playerBase.transform.Find ("LeftMouseSkill").GetComponentInChildren<ISkill> ();
        leftMouseSkill.Init (stateMachine, playerBase);
        //        leftMouseSkill.onStart (); 
        //目前已经将基础属性都放在Init中，看onStart还需不需要，或者用在别的地方上
    }
    public void Update () {
        currentState.Update ();
        leftMouseSkill.onUpdate ();
        if (Input.GetMouseButtonDown (0)) {
            leftMouseSkill.onStart (EveryFunction.GetMouseWorldPosition ());
            leftMouseSkill.onAttack ();
        }
        if (Input.GetMouseButtonDown (1)) { }

    }
    public void Exit () { }

    public void ChangeState (StateType nextStateType) {
        if (currentState != null) {
            currentState.Exit ();
        }
        currentState = states[nextStateType];
        currentState.Start ();
    }
    public IState GetCurrentState () {
        return currentState;
    }
}