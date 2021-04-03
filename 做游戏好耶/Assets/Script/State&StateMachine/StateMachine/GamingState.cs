using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Skill;
using UnityEngine;
public class GamingState : IState, IStateMachine {
    private CharacterSkillManager skillManager;
    private CharacterSkillSystem skillSystem;
    private IStateMachine stateMachine;
    private PlayerBase playerBase;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState> ();
    private IState currentState;
    public GamingState (IStateMachine stateMachine, PlayerBase playerBase) {
        this.stateMachine = stateMachine;
        this.playerBase = playerBase;
        this.skillManager = playerBase.GetComponent<CharacterSkillManager> ();
        this.skillSystem = playerBase.GetComponent<CharacterSkillSystem> ();
        states.Add (StateType.Idle, new PlayerIdleState (this, playerBase));
        states.Add (StateType.Hurt, new PlayerHurtState (this, playerBase));
        states.Add (StateType.Dead, new PlayerDeadState (this, playerBase));
        ChangeState (StateType.Idle);
    }
    public void Start () {
        //初始化
        //        leftMouseSkill.onStart (); 
        //目前已经将基础属性都放在Init中，看onStart还需不需要，或者用在别的地方上
    }
    public void Update () {
        currentState.Update ();
        if (Input.GetMouseButtonDown (0)) {
            Vector3 targetPosition = EveryFunction.GetMouseWorldPosition ();
            Quaternion quaternion = Quaternion.Euler (0, 0, EveryFunction.GetAngleOfTransform (playerBase.transform.position, targetPosition));
            /*  SkillData data = skillManager.PrepareSkill (1001);
             if (data != null) {
                 skillManager.GenerateSkill (data, quaternion);
             } */
            /*             leftMouseSkill.onStart (EveryFunction.GetMouseWorldPosition ());
                        leftMouseSkill.onAttack ();
             */
            int id = 1001;
            skillSystem.AttackUseSkill (id);
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