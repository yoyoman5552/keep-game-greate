using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class AttractEffect : MonoBehaviour, IEffect {
    //Attract:吸引效果
    public float StrikeLength; //吸引距离
    public void Effect (IBase activeTarget, IBase passiveTarget) {
        Vector3 strikeDirection = EveryFunction.GetNormalDirection (activeTarget.transform.position, passiveTarget.transform.position);
        passiveTarget.GetRigidbody ().MovePosition (passiveTarget.transform.position - strikeDirection * StrikeLength);
    }
}