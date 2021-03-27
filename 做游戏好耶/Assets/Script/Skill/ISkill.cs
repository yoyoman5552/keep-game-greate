using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ISkill {
    void Init (IStateMachine stateMachine, IBase characterBase); //初始化
    void onStart (Vector3 targetPosition);
    void onAttack ();
    void onUpdate ();
    void onExit ();
    void SetTargetPosition (Vector3 targetPosition);
}