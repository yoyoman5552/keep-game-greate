using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class EnemySystem : MonoBehaviour, IStateMachine {
    private CharacterBase characterBase;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState> ();
    private IState currentState;
    // Start is called before the first frame update
    void Start () {
        characterBase = GetComponent<CharacterBase> ();
        states.Add (StateType.Idle, new IdleState (this, characterBase));
        states.Add (StateType.Patrol, new PatrolState (this, characterBase));
        states.Add (StateType.Chase, new ChaseState (this, characterBase));
        ChangeState (StateType.Idle);
        //        currentState=states.
    }

    // Update is called once per frame
    void Update () {
        //        Debug.Log (currentState);
        currentState.Update ();
        if (Input.GetMouseButtonDown (0)) {
            ChangeState (StateType.Chase);
        }
        if (Input.GetMouseButtonDown (1)) {
            ChangeState (StateType.Idle);
        }
    }
    public void ChangeState (StateType nextStateType) {
        if (currentState != null) {
            currentState.Exit ();
        }
        currentState = states[nextStateType];
        currentState.Start ();
    }
}