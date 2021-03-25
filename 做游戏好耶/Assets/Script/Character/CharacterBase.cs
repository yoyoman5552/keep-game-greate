using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : IBase {
    /*
    CharacterBase:NPC、敌人属性
    Ibase属性：health、m_health、MaxHealth
    */
    public float patrolSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform patrolGrid;
    private Transform[] patrolPoints;
    //    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;
    // Start is called before the first frame update
    void Awake () {
        m_health = MaxHealth;
        rigidbody = GetComponent<Rigidbody2D> ();
    }
    void Start () {
        //速度不能设置为0
        if (patrolSpeed <= 0) Debug.Log ("速度不能设置为0：" + gameObject.name);
        //初始化数值
        patrolPoints = new Transform[2];
        patrolPoints[0] = patrolGrid.GetChild (0);
        patrolPoints[1] = patrolGrid.GetChild (1);
    }

    // Update is called once per frame
    void Update () {
        ChangeSprite (rigidbody.velocity.x);
    }
    public override void ChangeHealth (int dheal) {
        m_health = Mathf.Clamp (m_health + dheal, 0, MaxHealth);
    }
    public Vector3 GetPatrolPoints (int index) {
        if (index >= 0 && index < 2) {
            //获取PatrolPoints
            return patrolPoints[index].position;
        }

        return Vector3.zero;
    }
}