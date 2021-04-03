using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Character;
using EveryFunc.Skill;
using UnityEngine;
public class FarRangeSkillDeployer : SkillDeployer {
    //远距离攻击释放器
    public override void DeploySkill () {
        //设置父对象：使技能跟随父对象移动
        if (skillData.isFollowCharacter) transform.SetParent (skillData.owner.transform);
        //获取释放者的属性
        CharacterData characterData = skillData.owner.GetComponent<CharacterStatus> ().data;
        if (characterData != null)
            //设置技能释放位置
        //执行选区算法
        CalculateTargets ();
        //执行影响算法
        ImpactTargets ();
    }
}