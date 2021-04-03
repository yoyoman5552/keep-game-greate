using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Skill;
using UnityEngine;

public class CloseRangeSkillDeployer : SkillDeployer {
    //近身攻击释放器
    public override void DeploySkill () {
        //设置父对象：使技能跟随父对象移动，并且技能目标位置设置在父对象身上
        if (skillData.isFollowCharacter) transform.SetParent (skillData.owner.transform);
        //执行选区算法
        CalculateTargets ();

        //执行影响算法
        ImpactTargets ();
    }
}