using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public interface IStateMachine {
    void ChangeState (StateType nextStateType);
}