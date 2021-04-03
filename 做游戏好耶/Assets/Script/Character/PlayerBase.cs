using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerBase : IBase {
    /*
    PlayerBase：玩家属性
    Ibase属性：health、health、MaxHealth
    */
    private float invisibletimer;

    void Awake () {
        //基类初始化
        IBaseInit ();
    }
    private void Start () {
        //获取gamingState
        stateMachine = GetComponent<PlayerSystem> ().GetGamingState ();
    }
    // Update is called once per frame
    void Update () {

        ChangeSprite (rigidbody.velocity.x);
    }
    public override void ChangeSprite (float direction) {
        if (transform.position.x > EveryFunction.GetMouseWorldPosition ().x) {
            selfObject.localScale = new Vector3 (-1, 1, 1);
        } else {
            selfObject.localScale = new Vector3 (1, 1, 1);
        }
    }
    public override void TakenDamage (int damage) {
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
}