using UnityEngine;

namespace EveryFunc.Skill {
    //影响效果接口
    public interface IImpactEffect {
        //伤害生命
        void Execute (SkillDeployer deployer);

    }
}