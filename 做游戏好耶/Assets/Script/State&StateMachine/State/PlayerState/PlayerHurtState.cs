using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerHurtState : IState {
    //PatrolState的代码基本和MoveRoamRandom相同，MoveRoamRandom的作用是人物装上之后就只会移动
    //MoveRoamRandom如果给不需要对话的人装上，变成只会移动的npc
    private IStateMachine stateMachine;
    private IBase characterBase;
    private SpriteRenderer spriteRenderer; //获取人物的贴图属性
    private float hurtTime; //伤害颜色持续时间
    private float hurtCounter; //伤害计时器
    private SkillClass hurtedSkill; //受到的技能伤害
    //    private DamageType hurtDamageType; //受到的伤害种类
    public PlayerHurtState (IStateMachine stateMachine, IBase characterBase) {
        this.stateMachine = stateMachine;
        this.characterBase = characterBase;
        this.spriteRenderer = characterBase.GetSelfObject ().GetComponent<SpriteRenderer> ();
        hurtTime = ConstantList.HURTCOLORTIME;
    }
    public void Start () {
        //获取受到伤害的技能类型
        hurtedSkill = characterBase.GetHurtedSkill ();
        HurtedReact ();
    }
    public void Update () {
        if (hurtCounter > 0) hurtCounter -= Time.deltaTime;
        else {
            HurtedReback ();
        }
    }
    public void Exit () {
        //结束无敌状态（isHurted)
        characterBase.HurtedOut ();
    }
    public void HurtedReact () { //受伤反应
        //开启受伤计时器
        hurtCounter = hurtTime;
        //将受击的颜色开启
        ChangeHurtSPColor (1);
        PhysicReact ();
    }
    public void PhysicReact () { //物理上的反应
        if (hurtedSkill.GetDamageEffect () != null)
            hurtedSkill.GetDamageEffect ().Effect (hurtedSkill.GetBase (), characterBase);
    }
    public void HurtedReback () {
        //将受击的颜色关闭
        ChangeHurtSPColor (0);
        //检测时是否死亡，在这里检测是因为先播放受击效果
        if (characterBase.health == 0) {
            stateMachine.ChangeState (StateType.Dead);
        }
        //返回默认状态
        stateMachine.ChangeState (StateType.Idle);
    }
    public void ChangeHurtSPColor (float flag) { //改变受击颜色
        spriteRenderer.material.SetFloat ("_FlashAmount", flag);
    }
}