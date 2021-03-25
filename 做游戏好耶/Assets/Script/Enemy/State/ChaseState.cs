using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class ChaseState : IState {
    //PatrolState的代码基本和MoveRoamRandom相同，MoveRoamRandom的作用是人物装上之后就只会移动
    //MoveRoamRandom如果给不需要对话的人装上，变成只会移动的npc
    private IStateMachine stateMachine;
    private CharacterBase characterBase;
    private Vector3 leftDownPosition;
    private Vector3 rightUpPosition;
    private float chaseSpeed; //追击速度
    private float randomDistanceX;
    private float randomDistanceY;
    private float arrivedAtPositionMinDistance = 1f; //到达目标点的最短距离
    private Transform target;
    public ChaseState (IStateMachine stateMachine, CharacterBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
    }
    public void Start () {
        //初始化
        leftDownPosition = characterBase.GetPatrolPoints (0);
        rightUpPosition = characterBase.GetPatrolPoints (1);
        SetLimitArea (leftDownPosition, rightUpPosition);
        chaseSpeed = characterBase.chaseSpeed;
        this.characterBase.GetComponent<IMoveVelocity> ().SetMoveSpeed (chaseSpeed);
        target = characterBase.target;
    }
    public void Update () {
        SetMovePosition ();
        if (Vector3.Distance (characterBase.transform.position, target.position) < arrivedAtPositionMinDistance) {
            Debug.Log ("catch u!");
            stateMachine.ChangeState (StateType.Idle);
        }
    }
    public void Exit () {
        this.characterBase.GetComponent<IMoveVelocity> ().SetMoveSpeed (0f);
        characterBase.GetComponent<IMovePosition> ().SetPosition (characterBase.transform.position, leftDownPosition, rightUpPosition);
    }
    private void SetMovePosition () {
        //如果有路径就进行移动
        if (EveryFunction.getPath (characterBase.transform.position, target.position, leftDownPosition, rightUpPosition) != null) {
            characterBase.GetComponent<IMovePosition> ().SetPosition (target.position, leftDownPosition, rightUpPosition);
        } else {
            //如果没有路径就返回Idle状态
            stateMachine.ChangeState (StateType.Idle);
        }
    }
    public void SetLimitArea (Vector3 leftDownPosition, Vector3 rightUpPosition) {
        randomDistanceX = (rightUpPosition.x - leftDownPosition.x) / 2;
        randomDistanceY = (rightUpPosition.y - leftDownPosition.y) / 2;
    }
}