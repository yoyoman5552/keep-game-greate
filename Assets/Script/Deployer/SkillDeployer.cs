using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Skill;
using UnityEngine;

//技能释放器：将data内的选择方法和释放方式存储并制造出方法来释放它们
public abstract class SkillDeployer : MonoBehaviour {
    //技能数据
    private SkillData sd;
    //选区
    private IAttackSelector selector;
    //影响
    private IImpactEffect[] impactArray;
    public SkillData skillData {
        get {
            return sd;
        }
        set {
            sd = value;
            //初始化释放器：内部创建算法对象
            initDeployer ();
        }
    }
    //初始化释放器
    private void initDeployer () {
        //存储选择方法和影响效果
        selector = DeployConfigFactory.CreateAttackSelector (skillData);

        impactArray = DeployConfigFactory.CreateImpactEffect (skillData);
    }

    //执行算法对象
    //选区
    public void CalculateTargets () {
        //攻击目标设置，在子类的DeploySkill中调用
        skillData.attackTargets = selector.SelectTarget (skillData, transform);
    }

    //影响
    public void ImpactTargets () {
        for (int i = 0; i < impactArray.Length; i++) {
            //如果不为空
            if (impactArray[i] != null)
                impactArray[i].Execute (this);
        }
    }
    //释放方式
    public abstract void DeploySkill (); //供技能管理器调用，由子类实现:看会调用多少次的选区/影响

}