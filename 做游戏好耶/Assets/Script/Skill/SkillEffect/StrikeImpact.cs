using EveryFunc.Skill;
using UnityEngine;
namespace EveryFunc.Skill {
    public class StrikeImpact : IImpactEffect {
        private float strikeLength=1f;
        public void Execute (SkillDeployer deployer) {
            foreach (var targets in deployer.skillData.attackTargets) {
                if (targets != null) {
                    Vector3 strikeDirection = EveryFunction.GetNormalDirection (deployer.skillData.owner.transform.position, targets.transform.position);
                    var characterBase = targets.GetComponent<IBase> ();
                    characterBase.GetRigidbody ().MovePosition (targets.transform.position + strikeDirection * strikeLength);
                }
            }
        }
    }
}