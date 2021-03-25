using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : IBase {
    /*
    PlayerBase：玩家属性
    Ibase属性：health、m_health、MaxHealth
    */
    [SerializeField] private float InvisibleTime;
    private bool isInvisible; //是否无敌
    private float invisibletimer;
    // Start is called before the first frame update
    void Awake () {
        m_health = MaxHealth;
        rigidbody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (isInvisible) {
            invisibletimer -= Time.deltaTime;
            if (invisibletimer < 0) isInvisible = false;
        }
        ChangeSprite (rigidbody.velocity.x);
    }
    public override void ChangeHealth (int dheal) {
        if (dheal < 0) {
            if (isInvisible) return; //如果不是无敌
            isInvisible = true;
            invisibletimer = InvisibleTime;
        }
        m_health = Mathf.Clamp (m_health + dheal, 0, MaxHealth);
    }

}