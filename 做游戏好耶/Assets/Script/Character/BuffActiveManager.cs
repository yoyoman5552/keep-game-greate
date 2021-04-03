using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
namespace EveryFunc.Character {
    //状态显示器
/*     public class BuffActiveManager {
        [Tooltip ("Buff游戏物体名称")]
        public string selectedName = "Buffs";
        public Dictionary<BuffType, GameObject> buffs = new Dictionary<BuffType, GameObject> ();
        //初始化
        public void Init (CharacterStatus status) {
            //通过搜索物体身上的buffs物体，获取其全部子物体
            BuffActive[] targetOBJ = status.transform.Find (selectedName).GetComponentsInChildren<BuffActive> ();
            foreach (var target in targetOBJ) {
                BuffType buffType = (BuffType) Enum.Parse (typeof (BuffType), target.name);
                Debug.Log (buffType.ToString ());
                buffs.Add (buffType, target.gameObject);
            }
        }
    } */
}