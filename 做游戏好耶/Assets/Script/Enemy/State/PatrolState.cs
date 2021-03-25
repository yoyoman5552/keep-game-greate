using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PatrolState : IState {
    //PatrolState的代码基本和MoveRoamRandom相同，MoveRoamRandom的作用是人物装上之后就只会移动
    //MoveRoamRandom如果给不需要对话的人装上，变成只会移动的npc
    private IStateMachine stateMachine;
    private CharacterBase characterBase;
    private Vector3 leftDownPosition;
    private Vector3 rightUpPosition;
    private float minRandomDistace;
    private float maxRandomDistance;
    private float arrivedAtPositionMinDistance = 1f; //到达目标点的最短距离
    private float patrolSpeed; //Patrol移动速度
    private Vector3 startPosition;
    private Vector3 targetMovePosition;
    private bool isWalking;
    public PatrolState (IStateMachine stateMachine, CharacterBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
    }
    public void Start () {
        //初始化
        leftDownPosition = characterBase.GetPatrolPoints (0);
        rightUpPosition = characterBase.GetPatrolPoints (1);
        SetLimitArea (leftDownPosition, rightUpPosition);
        startPosition = characterBase.transform.position;
        patrolSpeed = characterBase.patrolSpeed;
        this.characterBase.GetComponent<IMoveVelocity> ().SetMoveSpeed (patrolSpeed);
        SetTargetMovePosition ();
    }
    public void Update () {
        //如果到达目标位置就回到Idle状态
        if (Vector3.Distance (characterBase.transform.position, targetMovePosition) < arrivedAtPositionMinDistance) {
            stateMachine.ChangeState (StateType.Idle);
        }
        if (!isWalking) SetMovePosition ();
    }
    public void Exit () {
        StopMovePosition ();
    }
    public void SetTargetMovePosition () {
        //设置随机移动位置
        targetMovePosition = startPosition + EveryFunction.GetRandomDir () * Random.Range (minRandomDistace, maxRandomDistance);
        isWalking = false;
    }
    public void StopMovePosition () {
        //停止移动——将目标位置调整到自身脚下，运行一遍寻路，这样马上就会结束
        targetMovePosition = characterBase.transform.position;
        SetMovePosition();
    }
    private void SetMovePosition () {
        //如果有路径就进行移动
        if (EveryFunction.getPath (characterBase.transform.position, targetMovePosition, leftDownPosition, rightUpPosition) != null) {
            characterBase.GetComponent<IMovePosition> ().SetPosition (targetMovePosition, leftDownPosition, rightUpPosition);
            isWalking = true;
        } else {
            //没有路径就切换状态机到Patrol,等于从来一次
            stateMachine.ChangeState (StateType.Patrol);
            //            targetMovePosition = characterBase.transform.position;
        }
    }
    public void SetLimitArea (Vector3 leftDownPosition, Vector3 rightUpPosition) {
        minRandomDistace = 3f;
        maxRandomDistance = Mathf.Max (rightUpPosition.x - leftDownPosition.x, rightUpPosition.y - leftDownPosition.y) / 2;
        // randomDistanceX = (rightUpPosition.x - leftDownPosition.x) / 2;
        // randomDistanceY = (rightUpPosition.y - leftDownPosition.y) / 2;
    }
}