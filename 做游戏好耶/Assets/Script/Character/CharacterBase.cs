using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class CharacterBase : IBase {
    /*
    CharacterBase:NPC、敌人属性
    Ibase属性：health、m_health、MaxHealth
    */
    //散步速度、追击速度、待机时间
    public float patrolSpeed;
    public float chaseSpeed;
    public float idleTime;
    //寻路相关：网格和可走区域限制
    public Transform patrolGrid;
    private Transform[] patrolPoints;
    //    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;

    // Start is called before the first frame update
    void Awake () {

        IBaseInit ();
    }
    void Start () {
        //速度不能设置为0
        if (patrolSpeed <= 0) Debug.Log ("速度不能设置为0：" + gameObject.name);
        //初始化数值
        patrolPoints = new Transform[2];
        patrolPoints[0] = patrolGrid.GetChild (0);
        patrolPoints[1] = patrolGrid.GetChild (1);
        //获取自身的状态机
        stateMachine = GetComponent<IStateMachine> ();
    }

    // Update is called once per frame
    void Update () {
        ChangeSprite (rigidbody.velocity.x);
    }
    /*     public override void ChangeHealth (int dheal) {
            SetHealth (dheal);
        } 
         public override void TakenDamage (int damage, ISkill getHurtedSkill) {
            if (isHurted) return; //如果是已经被攻击就返回，不受伤害
            //收集此攻击的种类
            isHurted = true;
            Debug.Log ("TakenDamage:" + isHurted);
            this.getHurtedSkill = getHurtedSkill;
            //无敌时间的取消不要在这里执行，在动画处执行
            //在未插电的电脑玩的状况下，电脑的帧率不高，若无敌时间(HurtedTime)过短，会无法被EnemySystem检测到被攻击了
            //解决方法：将HurtedOut运行在状态机之中，HurtState之后
    //        Invoke ("HurtedOut", HurtedTime);
            SetHealth (-damage);
        } */
    public Vector3 GetPatrolPoints (int index) {
        if (index >= 0 && index < 2) {
            //获取PatrolPoints
            return patrolPoints[index].position;
        }

        return Vector3.zero;
    }
}