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
        public void SetStateActive (bool state) {

        }
        //生命值减少
        public void TakenDamage (int damage) {
            data.health -= damage;
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
        //
        public IEnumerator BuffActiveDelay (float delay, bool state) {
            yield return new WaitForSeconds (delay);
        }
    }
}