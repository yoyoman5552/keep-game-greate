using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class StrikeEffect : MonoBehaviour, IEffect {
    //Strike:击退效果
    public float StrikeLength; //击退距离
    public void Effect (IBase activeTarget, IBase passiveTarget) {
        Vector3 strikeDirection = EveryFunction.GetNormalDirection (activeTarget.transform.position, passiveTarget.transform.position);
        passiveTarget.GetRigidbody ().MovePosition (passiveTarget.transform.position + strikeDirection * StrikeLength);
    }
}