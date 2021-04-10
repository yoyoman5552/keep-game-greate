using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc.Skill;
using UnityEngine;
public class AnimationAction : MonoBehaviour {
    private SkillDeployer deployer;
    private CharacterSkillSystem skillSystem;
    public void Awake () {
        deployer = this.GetComponentInParent<SkillDeployer> ();
        skillSystem = this.GetComponentInParent<CharacterSkillSystem> ();
    }
    public void Action () {
        if (deployer != null) {
            //相机摇晃
//            GameController.Instance.cameraController.CameraShake (0.1f, deployer.skillData.atkRatio);
            //技能释放
            deployer.DeploySkill ();
        }
        if (skillSystem != null) {
            skillSystem.DeploySkill ();
        }
    }
}