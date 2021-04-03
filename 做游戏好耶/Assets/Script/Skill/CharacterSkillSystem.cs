using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.Skill {
    //封装技能系统，提供简单的技能释放功能
    //让技能的输入和逻辑分离
    //一定需要技能管理器：CharacterSkillManager
    [RequireComponent (typeof (CharacterSkillManager))]
    public class CharacterSkillSystem : MonoBehaviour {
        private CharacterSkillManager skillManager;
        private Animator anim;
        private SkillData skill;
        private Transform selectedTarget; //选中的目标
        private void Start () {
            //获取角色的技能管理器和动画状态机
            skillManager = GetComponent<CharacterSkillManager> ();
            anim = GetComponentInChildren<Animator> ();
            //GetComponentInChildren<AnimationEvent> ().attackHandler += DeploySkill;
        }
        //生成技能
        private void DeploySkill (Vector3 deployPosition) {
            skillManager.GenerateSkill (skill, deployPosition);
        }
        //使用技能攻击,玩家直接用这个
        public void AttackUseSkill (int skillId) {
            //准备技能
            skill = skillManager.PrepareSkill (skillId);
            //如果技能无法使用（在cd或者不存在）
            if (skill == null) return;
            //播放动画:人物动画 非技能动画 技能动画生成自己播放
            //            anim.SetBool (skill.animationName, true);

            //如果技能释放者是玩家，就不需要瞄准敌人：由鼠标瞄准
            if (this.tag == "Player") {
                DeploySkill (EveryFunction.GetMouseWorldPosition ());
                return;
            }
            //以下为npc的判断方式
            //如果是多攻，就不调用下面的方法了
            if (skill.attackType != AttackType.Single) {
                return;
            }
            //如果单攻
            //--朝向目标,生成技能的时候把朝向传输进去
            Transform targetTF = SelectTarget ();
            if (targetTF != null) {
                DeploySkill (targetTF.position);
            }
            //--选中目标:先取消上一次目标，再选中本次的目标
            //核心思想：存储上次选中的物体
            //先取消上次选中的物体
            SetSelectedActiveFX (false);
            //目标切换成当前的目标
            selectedTarget = targetTF;
            //激活当前的目标
            SetSelectedActiveFX (true);
            //因为现在没有动画/动画事件不会弄 默认为直接生成技能
            //            DeploySkill ();
        }

        //使用随机技能——为NPC提供（非玩家控制角色）
        public void UseRandomSkill () {
            //需求：从管理器中产生随机技能
            //先筛选出所有可以释放的技能，再产生随机数
            var usableSkills = skillManager.skills.FindAll (s => (skillManager.PrepareSkill (s.skillId) != null));
            //如果没有可用的技能，就返回
            if (usableSkills.Length == 0) return;
            int index = UnityEngine.Random.Range (0, usableSkills.Length);
            AttackUseSkill (usableSkills[index].skillId);

        }

        //设置目标选择状态
        public void SetSelectedActiveFX (bool state) {
            if (selectedTarget == null) return;
            var selected = selectedTarget.GetComponent<CharacterSelected> ();
            if (selected) selected.setSelectedActive (state);
        }
        private Transform SelectTarget () {
            //在自己周遭查找目标并选择
            Transform[] targets = new SectorAttackSelector ().SelectTarget (skill, transform);
            //如果targets不为空，就返回第一个目标，否则返回null
            return targets.Length != 0 ? targets[0] : null;
        }
    }
}