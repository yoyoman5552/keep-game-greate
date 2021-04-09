using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.Character {
    //角色基本属性类
    [RequireComponent (typeof (Rigidbody2D))]
    [Serializable]
    public class CharacterData {
        //角色ID 
        public int CharacterID;
        //最大生命值
        public int MaxHealth;
        //用于设置当前生命值
        [HideInInspector] public int health { get { return currentHealth; } set { currentHealth = Mathf.Clamp (value, 0, MaxHealth); } }
        //当前生命值
        private int currentHealth;
        //护盾
        public int MaxShield;
        //用于设置当前护盾值
        [HideInInspector] public int shield { get { return currentShield; } set { currentShield = Mathf.Clamp (value, 0, MaxShield); } }
        //当前护盾值
        private int currentShield;
        //攻击力
        public int damage;
        //暴击几率
        public float deepDamageRatio;

        //治愈力
        public int healingPower;
        //CD影响力
        public float cdEffectPower;
        //移动速度
        public float Speed;
        [HideInInspector] public float moveSpeed {
            get { return m_speed; } set {
                m_speed = Mathf.Max (0, value);
                //脚本速度设置
                moveVelocity.SetMoveSpeed (m_speed);
            }
        }
        private float m_speed;
        //最大最小随机攻击buff是为了让伤害不是一成不变，随机值定为0~5
        //最小随机攻击buff
        [HideInInspector] public int minRandomDamage = 0; //伤害最小随机值
        //最大随机攻击buff
        [HideInInspector] public int maxRandomDamage = 5; //伤害最大随机值
        //自身Object获取，为了自身贴图转向，动画状态机也是在selfTexture上面
        [HideInInspector] public Transform selfTexture;
        [HideInInspector] public Material material;
        //受伤变红的计时器
        [HideInInspector] public float textureTime;
        //自身的动画状态机Animator
        [HideInInspector] public Animator animator;

        //被攻击后的小小无敌时间、是否被攻击、被什么技能伤害
        //无敌时间主要是防止被同一次攻击计算多次伤害，所以无敌时间很短：0.005(WUDITIME)
        //无敌时间
        [HideInInspector] public float HurtedTime;
        //是否被攻击了
        [HideInInspector] public bool isHurted;
        //Buff管理器
        //        [HideInInspector] public BuffActiveManager buffManager;
        //CHaracterStatus对象：获取实例对象
        [HideInInspector] public CharacterStatus status;
        //rigidbody组件
        [HideInInspector] public Rigidbody2D rigidbody;
        public void Init (CharacterStatus status) {
            //自身属性初始化
            this.status = status;
            rigidbody = status.GetComponent<Rigidbody2D> ();
            moveVelocity = status.GetComponent<IMoveVelocity> ();
            moveSpeed = Speed;
            health = MaxHealth;
            selfTexture = status.transform.Find ("SelfObject");
            material = selfTexture.GetComponent<SpriteRenderer> ().material;
            textureTime = ConstantList.HURTCOLORTIME;
            HurtedTime = ConstantList.WUDITIME;
        }
        /*         //攻击目标的位置
                [HideInInspector] public Transform target;
         */
        //移动脚本
        private IMoveVelocity moveVelocity;
    }
}