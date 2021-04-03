using UnityEngine;
using System;

namespace EveryFunc.Skill{
    //攻击选取的接口
    //功能搜索目标
public interface IAttackSelector{
    //skillData：技能数据
    //skillTF：技能所在物体的变换组件，不是释放者的组件
    Transform[] SelectTarget(SkillData skillData,Transform skillTF);
}

}
