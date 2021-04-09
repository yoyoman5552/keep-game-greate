using System.Collections;
using System.Collections.Generic;
using EveryFunc.Character;
using UnityEngine;
public class MoveRigidbodyVelocity : MonoBehaviour, IMoveVelocity {
    private float moveSpeed;
    private Vector3 velocityVector;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    private CharacterStatus status;
    void Start () {
        rigidbody = GetComponent<Rigidbody2D> ();
        animator = GetComponentInChildren<Animator> ();
        status = GetComponent<CharacterStatus> ();
    }
    public void SetVelocity (Vector3 velocityVector) {
        if (velocityVector != Vector3.zero) animator.SetBool ("isWalking", true);
        else animator.SetBool ("isWalking", false);
        this.velocityVector = velocityVector;
    }
    void FixedUpdate () {
        rigidbody.velocity = velocityVector * moveSpeed;
        if (tag != "Player") {
            status.Flip (velocityVector.x);
        }
    }
    public void SetMoveSpeed (float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }
}