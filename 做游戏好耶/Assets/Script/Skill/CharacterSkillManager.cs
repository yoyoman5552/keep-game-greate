using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;

namespace EveryFunc.Skill {
    //技能管理器
    public class CharacterSkillManager : MonoBehaviour {
        public SkillData[] skills;
        private void Start () {
            for (int i = 0; i < skills.Length; i++) {
                //初始化所有技能

                InitSkill (skills[i]);
            }
        }
        //初始化技能
        public void InitSkill (SkillData data) {
            //设置预设体和设置技能所属
            //资源映射表：prefabName ——> prefabPath 以在Resources中获取prefab返回
            data.skillPrefab = ResourceManager.Load<GameObject> (data.prefabName);
            //        Debug.Log ("Init:"+data.skillPrefab.name);
            data.owner = gameObject;
        }
        //准备技能：查找并返回技能数据
        public SkillData PrepareSkill (int id) {
            //根据技能ID，查找技能数据
            SkillData data = skills.Find (s => s.skillId == id);
            //判断释放条件
            //如果找到了该技能而且技能冷却为0
            if (data != null) {
                if (data.cdTimer <= 0) {
                    return data;
                }
            }
            return null;
        }
        //生成技能需要知道的事情：技能数据，释放的目标位置
        public void GenerateSkill (SkillData data, Vector3 deployPosition) {
            //计算技能释放角度，默认为普通朝向（正向）
            Quaternion quaternion = transform.rotation;
            //如果跟随角色，就以角色为中心环绕
            if (data.isFollowCharacter) {
                quaternion = Quaternion.Euler (0, 0, EveryFunction.GetAngleOfTransform (data.owner.transform.position, deployPosition));
            }
            //创建技能预制件——通过对象池生成
            GameObject skillObj = GameObjectPool.Instance.CreateObject (data.prefabName, data.skillPrefab, deployPosition, quaternion);
            SkillDeployer skillDeployer = skillObj.GetComponentInChildren<SkillDeployer> ();

            //传递技能数据
            //内部创建算法对象
            skillDeployer.skillData = data;
            //播放动画
            skillObj.GetComponentInChildren<Animator> ().Play (skillDeployer.skillData.prefabName);
            //先播放动画再执行算法对象
            //内部执行算法对象
            //销毁技能
            GameObjectPool.Instance.CollectObject (skillObj, data.durationTime);
            //开启技能冷却
            StartCoroutine (CoolTimeDown (data));
        }
        private IEnumerator CoolTimeDown (SkillData data) {
            data.cdTimer = data.cdTime;
            while (data.cdTimer >= 0) {
                yield return new WaitForSeconds (0.5f);
                data.cdTimer--;
            }

        }
        private void DestroyObject (GameObject skillObj, float delay) {
            GameObjectPool.Instance.CollectObject (skillObj, delay);
        }
    }
}