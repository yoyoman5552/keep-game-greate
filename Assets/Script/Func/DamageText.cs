using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
using UnityEngine.UI;
public class DamageText : MonoBehaviour {
    //伤害数字上浮
    private Text damageText; //数字
    public float upSpeed; //上浮速度
    public float lifeTime; //存在时间
    private void Awake () {
        damageText = GetComponent<Text> ();
        Destroy (this.gameObject, lifeTime);
    }
    private void Update () {
        transform.position += new Vector3 (0, upSpeed * Time.deltaTime, 0);
    }
    public void SetUIDamage (int amount) {
        damageText.text = amount.ToString ();
    }
}