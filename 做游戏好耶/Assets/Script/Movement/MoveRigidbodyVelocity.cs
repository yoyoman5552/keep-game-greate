using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRigidbodyVelocity : MonoBehaviour, IMoveVelocity {
    [SerializeField] private float moveSpeed;
    private Vector3 velocityVector;
    private new Rigidbody2D rigidbody;
    void Awake () {
        rigidbody = GetComponent<Rigidbody2D> ();
    }
    public void SetVelocity (Vector3 velocityVector) {
        this.velocityVector = velocityVector;
    }
    void FixedUpdate () {
        rigidbody.velocity = velocityVector * moveSpeed;
    }
    public void SetMoveSpeed (float moveSpeed) {
        this.moveSpeed = moveSpeed;
    }
}