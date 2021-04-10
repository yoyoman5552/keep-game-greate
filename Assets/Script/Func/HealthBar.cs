using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using EveryFunc.Character;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
    //血量调整
    public Image hpImage;
    public Image hpEffectImage;
    private CharacterStatus characterStatus;
    [SerializeField] private float hurtSpeed = 0.005f;
    private void Start () {
        characterStatus = GetComponentInParent<CharacterStatus> ();
    }
    private void Update () {
        //生命值减缓效果
        hpImage.fillAmount = ((float) characterStatus.data.health) / characterStatus.data.MaxHealth; //要转换成float才能除
        if (hpEffectImage.fillAmount > hpImage.fillAmount) {
            hpEffectImage.fillAmount -= hurtSpeed;
//            if (hpImage.fillAmount == 0) this.gameObject.SetActive (false);
        } else {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }
}