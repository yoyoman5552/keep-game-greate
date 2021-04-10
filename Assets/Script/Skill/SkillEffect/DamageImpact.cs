using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc.Character;
using UnityEngine;
namespace EveryFunc.Skill {
    public class DamageImpact : IImpactEffect {
        //技能数据
        private SkillData skillData;
        //技能释放者的属性
        private CharacterStatus status;
        public void Execute (SkillDeployer deployer) {
            skillData = deployer.skillData;
            status = skillData.owner.GetComponent<CharacterStatus> ();
            deployer.StartCoroutine (RepeatDamage (deployer));
        }
        private IEnumerator RepeatDamage (SkillDeployer deployer) {
            //伤害计时器
            float atkTimer = 0;
            //伤害
            //技能攻击力=伤害比率*基础攻击力
            //最低随机伤害，最高随机伤害，原本的伤害值，附加随机之后的伤害值
            int minRandomDamage, maxRandomDamage, oriATK, atk;
            minRandomDamage = status.data.minRandomDamage;
            maxRandomDamage = status.data.maxRandomDamage;
            oriATK = Mathf.RoundToInt (status.data.damage * skillData.atkRatio);
            do {
                //伤害加上随机数
                atk = oriATK + UnityEngine.Random.Range (minRandomDamage, maxRandomDamage);
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
                    var characterBase = targets.GetComponent<CharacterStatus> ();
                    characterBase.TakenDamage (atk);
                } else {
                    Debug.Log ("targets null," + skillData.name);
                }
            }
            //创建攻击特效 看要不要放在这儿
        }
    }

}