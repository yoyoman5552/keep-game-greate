using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.Character {
    //角色方法类
    public class CharacterStatus : MonoBehaviour {
        //角色属性
        public CharacterData data;
        private void Awake () {
            //角色属性的一些变量的初始化和赋值
            data.Init (this);
        }

        //生命值减少
        public void TakenDamage (int damage) {
            if (data.isHurted) return;
            data.health -= damage;
            GetHurted ();
        }
        //翻转朝向
        public void Flip (float dir) {
            //如果dir为0就保持原样
            if (dir == 0) return;
            if (dir < 0) dir = -1;
            else dir = 0;
            data.selfTexture.eulerAngles = new Vector3 (0, 180 * dir, 0);
        }
        private void GetHurted () {
            //受到伤害，人物变红
            data.isHurted = true;
            data.material.SetFloat ("_FlashAmount", 1);
            data.textureTime=ConstantList.HURTCOLORTIME;
            Invoke ("HurtedOutDelay", data.HurtedTime);
        }
        private void HurtedOutDelay () {
            data.isHurted = false;
        }
        //生命值增加
        public void TakenHealing (int heal) {
            data.health += heal;
        }
        //设置移动速度
        public void SetMoveSpeed (float buffPercent) {
            //移动速度乘上一个百分比
            data.moveSpeed = Mathf.RoundToInt (data.Speed * buffPercent);
        }
        //重置移动速度
        public void ResetMoveSpeed () {
            //恢复移动速度
            data.moveSpeed = data.Speed;
        }
        private IEnumerator HurtedColorOutDelay(float delay){
            while(delay>0){
                
            }
            yield return new WaitForSeconds(0.01f);
        }
        private void Update () {
            //如果人物没有受到伤害
            if (data.textureTime <= 0) {
                //人物取消变红
                data.material.SetFloat ("_FlashAmount", 0);

            } else {
                data.textureTime -= Time.deltaTime;
            }
        }
    }
}