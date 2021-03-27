using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {
    //血量调整
    public Image hpImage;
    public Image hpEffectImage;
    private IBase characterBase;
    [SerializeField] private float hurtSpeed = 0.005f;
    private void Start () {
        characterBase = GetComponentInParent<IBase> ();
    }
    private void Update () {
        hpImage.fillAmount = ((float) characterBase.health) / characterBase.MaxHealth;//要转换成float才能除
        if (hpEffectImage.fillAmount > hpImage.fillAmount) {
            hpEffectImage.fillAmount -= hurtSpeed;
        } else {
            hpEffectImage.fillAmount = hpImage.fillAmount;
        }
    }
}