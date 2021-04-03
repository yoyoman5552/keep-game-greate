using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
[RequireComponent (typeof (Rigidbody2D))]
public abstract class IBase : MonoBehaviour {
    //伤害类变量
    public int selfDamage; //自身的伤害值
    public int minRandomDamage; //伤害最小随机值
    public int maxRandomDamage; //伤害最大随机值
    //最大生命值，只用于读取的生命值，当前生命值
    public int MaxHealth;
    public int health { get { return m_health; } }
    //m_health设置成public只是为了在Inspector上看见
    public int m_health;

    //自身Object获取，为了自身贴图转向
    protected Transform selfObject;
    protected new Rigidbody2D rigidbody;
    protected IStateMachine stateMachine; //获取自身的状态机
    //身体接触到的敌人
    protected Collider2D other;
    
    //被攻击后的小小无敌时间、是否被攻击、被什么技能伤害
    //无敌时间主要是防止被同一次攻击计算多次伤害，所以无敌时间很短：0.005(WUDITIME)
    protected float HurtedTime;
    public bool isHurted;
    public void IBaseInit () {
        HurtedTime = ConstantList.WUDITIME;
        m_health = MaxHealth;
        rigidbody = GetComponent<Rigidbody2D> ();
        selfObject = this.transform.Find ("SelfObject");
        isHurted = false;
    }
    public virtual void ChangeSprite (float direction) {
        if (direction != 0) {
            if (direction > 0) selfObject.localScale = new Vector3 (1, 1, 1);
            else selfObject.localScale = new Vector3 (-1, 1, 1);
        }
    }
    public virtual void ChangeHealth (int dheal) {
        //增加生命值
        SetHealth (dheal);
    }
    public virtual void TakenDamage (int damage) {
        if (isHurted) return; //如果是已经被攻击就返回，不受伤害
        //收集此攻击的种类
        isHurted = true;
        //生成damageText
        DamageText damageText = Instantiate (GameController.Instance.damageText, transform.position, Quaternion.identity, GameController.Instance.canvas.transform).GetComponent<DamageText> ();
        damageText.SetUIDamage (damage);
        SetHealth (-damage);
        //将状态转成受伤状态，倒计时无敌时间
        stateMachine.ChangeState (StateType.Hurt);

        Invoke ("HurtedOut", HurtedTime);
    }
    public void HurtedOut () {
        isHurted = false;
    }
    public bool GetIsHurted () {
        return isHurted;
    }
    public float GetHurtedTime () {
        return HurtedTime;
    }
    public Transform GetSelfObject () {
        return selfObject;
    }
    public void SetHealth (int dBuff) {
        this.m_health = Mathf.Clamp (health + dBuff, 0, MaxHealth);
    }

    public Rigidbody2D GetRigidbody () {
        return rigidbody;
    }
}