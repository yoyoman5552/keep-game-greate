using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbodyVelocity : MonoBehaviour, IMoveVelocity {
    [SerializeField] private float moveSpeed;
    private Vector3 velocityVector;
    private new Rigidbody2D rigidbody;
    private Animator animator;
    void Awake () {
        rigidbody = GetComponent<Rigidbody2D> ();
        animator = GetComponentInChildren<Animator> ();
    }
    public void SetVelocity (Vector3 velocityVector) {
        if (velocityVector != Vector3.zero) animator.SetBool ("isWalking", true);
        else animator.SetBool ("isWalking", false);
        this.velocityVector = velocityVector;
    }
    void FixedUpdate () {
        rigidbody.velocity = velocityVector * moveSpeed;
    }
    public void SetMoveSpeed (float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }
}