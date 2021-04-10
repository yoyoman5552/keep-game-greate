using System;
using EveryFunc.Skill;
using UnityEngine;
public class DeployConfigFactory {

    private void initDeployer () {

    }
    public static IAttackSelector CreateAttackSelector (SkillData skillData) {
        //选取命名规范：EveryFunc.Skill. + 枚举名 + AttackSelector
        //例子：EveryFunc.Skill.SectorAttackSelector
        string classNameSelector = string.Format ("EveryFunc.Skill.{0}AttackSelector", skillData.selectorType);
        return CreateObject<IAttackSelector> (classNameSelector);
    }
    public static IImpactEffect[] CreateImpactEffect (SkillData skillData) {
        //效果命名规范：EveryFunc.Skill. + 枚举名 + Impact
        //例子: EveryFunc.Skill.StrikeImpact
        IImpactEffect[] impactArrays = new IImpactEffect[skillData.impactType.Length];
        for (int i = 0; i < skillData.impactType.Length; i++) {
            string classNameImpact = string.Format ("EveryFunc.Skill.{0}Impact", skillData.impactType[i]);
            impactArrays[i] = CreateObject<IImpactEffect> (classNameImpact);
        }
        return impactArrays;

    }
    private static T CreateObject<T> (string className) where T : class {
        Type type = Type.GetType (className);
        if (type == null) return null;
        return Activator.CreateInstance (type) as T;
    }
}