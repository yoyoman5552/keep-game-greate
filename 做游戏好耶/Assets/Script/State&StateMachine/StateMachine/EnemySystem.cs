using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Skill;
using UnityEngine;
public class EnemySystem : MonoBehaviour, IStateMachine {
    private CharacterBase characterBase;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState> ();
    private IState currentState;
    private CharacterSkillManager skillManager;
    // Start is called before the first frame update
    void Start () {
        characterBase = GetComponent<CharacterBase> ();
        states.Add (StateType.Idle, new IdleState (this, characterBase));
        states.Add (StateType.Patrol, new PatrolState (this, characterBase));
        states.Add (StateType.Chase, new ChaseState (this, characterBase));
        states.Add (StateType.Hurt, new HurtState (this, characterBase));
        states.Add (StateType.Dead, new DeadState (this, characterBase));
        //        bodyDamage = new BodyDamage (this, characterBase);
        ChangeState (StateType.Idle);
        this.skillManager = characterBase.GetComponent<CharacterSkillManager> ();
        SkillData data = skillManager.PrepareSkill (1002);
        /*         if (data != null)
                    skillManager.GenerateSkill (data);
         */
    }

    // Update is called once per frame
    void Update () {
        currentState.Update ();
        /*         SkillData data = skillManager.PreapareSkill (1002);
                if (data!=null)
                    skillManager.GenerateSkill (data);
         */
    }
    public void ChangeState (StateType nextStateType) {
        if (currentState != null) {
            currentState.Exit ();
        }
        currentState = states[nextStateType];
        currentState.Start ();
    }
    public void HurtedOut () {
        characterBase.HurtedOut ();
    }
    public IState GetCurrentState () {
        return currentState;
    }
}