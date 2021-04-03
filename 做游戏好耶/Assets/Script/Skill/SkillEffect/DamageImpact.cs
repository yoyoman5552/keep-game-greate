using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Skill;
using UnityEngine;
namespace EveryFunc.Skill {
    public class DamageImpact : IImpactEffect {
        private SkillData skillData;
        public void Execute (SkillDeployer deployer) {
            skillData = deployer.skillData;
            deployer.StartCoroutine (RepeatDamage (deployer));
        }
        private IEnumerator RepeatDamage (SkillDeployer deployer) {
            //伤害计时器
            float atkTimer = 0;
            //伤害
            //技能攻击力=伤害比率*基础攻击力
            int atk = Mathf.RoundToInt (skillData.atkRatio * skillData.owner.GetComponent<IBase> ().selfDamage);
            do {
                //攻击一次
                OnceDamage (atk);
                yield return new WaitForSeconds (skillData.atkInterval);
                //计时
                atkTimer += skillData.atkInterval;
                //重新计算一次目标
                deployer.CalculateTargets ();
            } while (atkTimer < skillData.durationTime);
        }
        private void OnceDamage (int atk) {
            foreach (var targets in skillData.attackTargets) {
                if (targets != null) {
                    var characterBase = targets.GetComponent<IBase> ();
                    characterBase.TakenDamage (atk);
                } else {
                    Debug.Log ("targets null," + skillData.name);
                }
            }
            //创建攻击特效 看要不要放在这儿
        }
    }

}