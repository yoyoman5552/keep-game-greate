using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerSystem : MonoBehaviour, IStateMachine {
    //人物状态机
    private PlayerBase playerBase;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState> ();
    private GamingState gamingState;
    private IState currentState;
    // Start is called before the first frame update
    void Start () {
        playerBase = GetComponent<PlayerBase> ();
        gamingState = new GamingState (this, playerBase);
        states.Add (StateType.Gaming, gamingState);
        //Chase的设置是为了在HurtState的状态下，能回到这里
        ChangeState (StateType.Gaming);
    }

    // Update is called once per frame
    void Update () {
        currentState.Update ();
    }
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
    public GamingState GetGamingState () {
        return gamingState;
    }
}